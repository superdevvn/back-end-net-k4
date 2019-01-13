using System;
using Models;
using Repositories;

namespace Services
{
    public abstract class BaseService <TEntity, TRepository>
        where TEntity : BaseEntity
        where TRepository: BaseRepository<TEntity>, new()
    {
        protected TRepository repository = new TRepository();
        public virtual TEntity Create(TEntity entity)
        {
            return repository.Create(entity);
        }

        public virtual TEntity Update(TEntity entity)
        {
            if (Get(entity.Id) == null) throw new Exception($"NOT FOUND ENTITY WITH ID {entity.Id.ToString()}");
            return repository.Update(entity);
        }

        public virtual TEntity Save(TEntity entity)
        {
            if (entity.Id != Guid.Empty) return Update(entity);
            else return Create(entity);
        }

        public virtual TEntity Get(Guid id)
        {
            return repository.Get(id);
        }
    }
}
