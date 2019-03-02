using Models;
using Models.Commons;
using Models.Interfaces;
using Repositories.Commons;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using Utilities;

namespace Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : class, IModel, IClient, ICreator
    {
        public virtual IPagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize)
        {
            using (var context = new SuperDevDbContext())
            {
                var query = context.Set<TEntity>()
                    .Where(whereClause);
                var items = query.OrderBy($"{orderBy} {orderDirection}")
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                return new PagedListResult(items, query.Count());
            }
        }

        public virtual IPagedListResult List(IPagedListRequest request)
        {
            return List(request.whereClause, request.orderBy, request.orderDirection, request.pageNumber, request.pageSize);
        }

        public virtual List<TEntity> All(string whereClause, string orderBy, string orderDirection)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().Where(whereClause).OrderBy($"{orderBy} {orderDirection}").ToList();
            }
        }

        public virtual TEntity One(string whereClause, string orderBy, string orderDirection)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().Where(whereClause).OrderBy($"{orderBy} {orderDirection}").FirstOrDefault();
            }
        }

        public virtual TEntity One(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().FirstOrDefault(e => e.id == id);
            }
        }        

        public virtual TEntity Create(TEntity entity, bool requireAuthorization = true)
        {
            entity.id = Guid.NewGuid();
            using (var context = new SuperDevDbContext())
            {
                context.Set<TEntity>().Add(entity);
                context.SaveChanges(requireAuthorization);
                context.Entry(entity).Reload();
                return entity;
            }
        }

        public virtual void Create(IEnumerable<TEntity> entities, bool requireAuthorization = true)
        {
            using (var context = new SuperDevDbContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                foreach (var entity in entities)
                {
                    entity.id = Guid.NewGuid();
                    context.Set<TEntity>().Add(entity);
                }
                context.ChangeTracker.DetectChanges();
                context.SaveChanges(requireAuthorization);
            }
        }

        public virtual TEntity Update(TEntity entity, bool requireAuthorization = true)
        {
            using (var context = new SuperDevDbContext())
            {
                TEntity origin = context.Set<TEntity>().Find(entity.id);
                Utility.CloneObject(origin, entity);
                context.SaveChanges(requireAuthorization);
                context.Entry(origin).Reload();
                return origin;
            }
        }

        public virtual void Update(IEnumerable<TEntity> entities, bool requireAuthorization = true)
        {
            using (var context = new SuperDevDbContext())
            {
                foreach (var entity in entities)
                {
                    TEntity origin = context.Set<TEntity>().Find(entity.id);
                    Utility.CloneObject(origin, entity);
                }
                context.SaveChanges(requireAuthorization);
            }
        }

        public void Delete(Guid id, bool requireAuthorization = true)
        {
            using (var context = new SuperDevDbContext())
            {
                var entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges(requireAuthorization);
            }
        }

        public void Delete(IEnumerable<Guid> ids, bool requireAuthorization = true)
        {
            using (var context = new SuperDevDbContext())
            {
                context.Configuration.AutoDetectChangesEnabled = false;
                var entities = context.Set<TEntity>().Where(e => ids.Contains(e.id));
                context.Set<TEntity>().RemoveRange(entities);
                context.ChangeTracker.DetectChanges();
                context.SaveChanges(requireAuthorization);
            }
        }
    }
}
