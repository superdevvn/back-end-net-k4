using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utilities;

namespace Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity
    {
        public virtual TEntity Create(TEntity entity)
        {
            using (var context = new SuperDevDbContext())
            {
                entity.Id = Guid.NewGuid(); // Gán ID mới
                entity.CreatedDate = DateTimeOffset.Now; // Gán ngày tạo
                entity.ModifiedDate = DateTimeOffset.Now; // Gán ngày cập nhật
                context.Set<TEntity>().Add(entity); // Add entity
                context.SaveChanges(); // Lưu xuống DB
                return context.Set<TEntity>().Find(entity.Id); // Trả kết quả về
            }
        }

        public virtual void Create(IEnumerable<TEntity> entities)
        {
            for (var i = 0; i < entities.Count(); i += 1000)
            {
                var subEntities = entities.Where((entity, index) =>
                {
                    return (index >= i && index < i + 1000);
                });
                using (var context = new SuperDevDbContext())
                {
                    context.Configuration.AutoDetectChangesEnabled = false;
                    foreach (var entity in subEntities)
                    {
                        entity.Id = Guid.NewGuid();
                        context.Set<TEntity>().Add(entity);
                    }
                    context.ChangeTracker.DetectChanges();
                    context.SaveChanges();
                }
            }
        }

        public virtual TEntity Update(TEntity entity)
        {
            using (var context = new SuperDevDbContext())
            {
                var originEntity = context.Set<TEntity>().Find(entity.Id); // Lấy dữ liệu từ DB
                Utility.CloneObject(originEntity, entity); // Gán từng thuộc tính của entity cho originEntity từ DB
                originEntity.ModifiedDate = DateTimeOffset.Now; // Gán ngày cập nhật mới
                context.SaveChanges(); // Lưu xuống DB
                return context.Set<TEntity>().Find(originEntity.Id); // Trả kết quả về
            }
        }

        public virtual TEntity Get(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().Find(id); // Trả kết quả về
            }
        }

        public virtual TEntity Get(string whereClause)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().Where(whereClause).FirstOrDefault();
            }
        }

        public virtual List<TEntity> All(string whereClause = "1>0")
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Set<TEntity>().Where(whereClause).ToList();
            }
        }

        public virtual void Delete(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                var entity = context.Set<TEntity>().Find(id);
                context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
