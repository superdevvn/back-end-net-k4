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
    }
}
