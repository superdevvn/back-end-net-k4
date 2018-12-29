using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Utilities;

namespace Repositories
{
    public abstract class BaseRepository<TEntity>
        where TEntity : BaseEntity, new()
    {
        public TEntity Create(TEntity entity)
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

        public TEntity Update(TEntity entity)
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
    }
}
