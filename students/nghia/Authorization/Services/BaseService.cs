using System;
using System.Collections;
using System.Collections.Generic;
using Models.Interfaces;
using Repositories;
using Repositories.Interfaces;
using Services.Exceptions;
using Utilities;

namespace Services
{
    public abstract class BaseService<TEntity, TBaseRepository>
        where TEntity : class, IModel, IClient, ICreator
        where TBaseRepository : BaseRepository<TEntity>, new()
    {
        // Private Properties & Methods
        private readonly string defaultWhereClause = "1>0";
        private readonly string defaultOrderBy = "createdDate";
        private readonly string defaultOrderDirection = "DESC";
        private string GenerateWhereClause(string whereClause, bool requireAuthorization = true)
        {
            if (string.IsNullOrWhiteSpace(whereClause)) whereClause = defaultWhereClause;
            if (requireAuthorization && !Utility.IsMasterClient) return $"clientId = GUID(\"{Utility.ClientId.ToString()}\") AND ({whereClause})";
            return whereClause;
        }

        // Protected Properties & Methods
        protected string entityName
        {
            get
            {
                return typeof(TEntity).Name;
            }
        }

        protected TBaseRepository repository = new TBaseRepository();

        // Public Properties & Methods
        public virtual IPagedListResult List(string whereClause, string orderBy, string orderDirection, int pageNumber, int pageSize, bool requireAuthorization = true)
        {
            whereClause = GenerateWhereClause(whereClause, requireAuthorization);
            return repository.List(whereClause, orderBy, orderDirection, pageNumber, pageSize);
        }

        public virtual IPagedListResult List(IPagedListRequest request)
        {
            return repository.List(request);
        }

        public virtual IEnumerable<TEntity> All(string whereClause, bool requireAuthorization = true)
        {
            whereClause = GenerateWhereClause(whereClause, requireAuthorization);
            return repository.All(whereClause, defaultOrderBy, defaultOrderDirection);
        }

        public virtual IEnumerable<TEntity> All(bool requireAuthorization = true)
        {
            return All(string.Empty, requireAuthorization);
        }

        public virtual TEntity One(Guid id, bool requireAuthorization = true)
        {
            var entity = repository.One(id);
            if (entity == null) throw new NotFoundException(entityName);
            return entity;
        }

        public virtual TEntity First(string columnName, string value, bool requireAuthorization = true)
        {
            string whereClause = $"{columnName} = \"{value}\"";
            whereClause = GenerateWhereClause(whereClause, requireAuthorization);

            var entity = repository.One(whereClause, defaultOrderBy, defaultOrderDirection);
            if (entity == null) throw new NotFoundException(entityName);
            return entity;
        }

        public virtual void Create(IEnumerable<TEntity> entities, bool requireAuthorization = true)
        {
            repository.Create(entities, requireAuthorization);
        }

        public virtual void Update(IEnumerable<TEntity> entities, bool requireAuthorization = true)
        {
            repository.Update(entities, requireAuthorization);
        }

        public virtual TEntity Create(TEntity entity, bool requireAuthorization = true)
        {
            return repository.Create(entity, requireAuthorization);
        }

        public virtual TEntity Update(TEntity entity, bool requireAuthorization = true)
        {
            if (requireAuthorization)
            {
                // Không cho phép cập nhật record của clientId khác nếu không phải là MasterClient
                if (entity.clientId != Utility.ClientId && !Utility.IsMasterClient) throw new Exception("CLIENTID NOT MATCH");
            }
            return repository.Update(entity, requireAuthorization);
        }

        public virtual TEntity Save(TEntity entity, bool requireAuthorization = true)
        {
            return entity.id == Guid.Empty ? Create(entity, requireAuthorization) : Update(entity, requireAuthorization);
        }

        public virtual TEntity Save(TEntity entity)
        {
            return Save(entity, true);
        }

        public virtual TEntity Approve(Guid id, bool requireAuthorization = true)
        {
            var model = One(id);
            if (model is IApprover)
            {
                var entity = model as IApprover;
                if (entity.approvedBy != null) throw new Exception("ENTITY APPROVED");
                entity.approvedBy = Utility.UserId;
                entity.approvedDate = DateTime.Now;
                entity.approver = Utility.Username;
            };
            return Update(model, requireAuthorization);
        }

        public virtual TEntity Unapprove(Guid id, bool requireAuthorization = true)
        {
            var model = One(id);
            if (model is IApprover)
            {
                var entity = model as IApprover;
                if (entity.approvedBy == null) throw new Exception("ENTITY UNAPPROVED");
                entity.approvedBy = null;
                entity.approvedDate = null;
                entity.approver = null;
            };
            return Update(model, requireAuthorization);
        }

        public virtual void Approve(IEnumerable<Guid> ids, bool requireAuthorization = true)
        {
            var entities = new List<TEntity>();
            foreach (var id in ids)
            {
                var model = One(id);
                if (model is IApprover)
                {
                    var entity = model as IApprover;
                    if (entity.approvedBy == null)
                    {
                        entity.approvedBy = Utility.UserId;
                        entity.approvedDate = DateTime.Now;
                        entity.approver = Utility.Username;
                        entities.Add(model);
                    }
                }
                if(requireAuthorization)
                {
                    // Không cho phép xóa record của clientId khác nếu không phải là MasterClient
                    if (model.clientId != Utility.ClientId && !Utility.IsMasterClient) throw new Exception("CLIENTID NOT MATCH");
                }
            }
            Update(entities, requireAuthorization);
        }

        public virtual void Delete(Guid id, bool requireAuthorization = true)
        {
            var entity = One(id);
            if (requireAuthorization)
            {
                // Không cho phép xóa record của clientId khác nếu không phải là MasterClient
                if (entity.clientId != Utility.ClientId && !Utility.IsMasterClient) throw new Exception("CLIENTID NOT MATCH");
            }
            repository.Delete(id, requireAuthorization);
        }

        public virtual void Delete(IEnumerable<Guid> ids, bool requireAuthorization = true)
        {
            
            if (requireAuthorization)
            {
                foreach(var id in ids)
                {
                    var entity = One(id);
                    // Không cho phép xóa record của clientId khác nếu không phải là MasterClient
                    if (entity.clientId != Utility.ClientId && !Utility.IsMasterClient) throw new Exception("CLIENTID NOT MATCH");
                }
            }
            repository.Delete(ids, requireAuthorization);
        }
    }
}