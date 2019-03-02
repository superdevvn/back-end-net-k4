using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models.Interfaces;
using Models.Exceptions;
using Utilities;
using Models.Attributes;
using Models.Commons;

namespace Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<User> Users { get; set; }
    }

    [MasterUserPermission]
    [CurrentUserPermission]
    public class User: BaseEntity, IBeforeSave
    {
        [Required]
        [StringLength(50)]
        [Index("IX_Username", IsUnique = true)]
        public string username { get; set; }

        [Required]
        [StringLength(32)]
        public string password { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(200)]
        public string fullName { get; set; }

        [StringLength(200)]
        public string address { get; set; }

        public bool isMaster { get; set; }

        public bool isActivated { get; set; }

        public void BeforeSave(DbContext context, DbEntityEntry entry, bool requireAuthorization = true)
        {
            var users = context.Set<User>();
            if(requireAuthorization)
            {
                if (entry.State == EntityState.Added)
                {
                    // Chỉ có masterUser mới được phép tạo mới dữ liệu
                    if (!Utility.IsMasterUser) throw new NoPermissionException();

                    // Chỉ có masterUser của masterClient mới được tạo dữ liệu user cho client khác
                    if (!Utility.IsMasterClient || !Utility.IsMasterUser && this.clientId != Utility.ClientId) throw new NoPermissionException();
                }
                else if (entry.State == EntityState.Modified)
                {
                    // Chỉ có masterUser hoặc chính user đó mới được phép chỉnh sửa dữ liệu
                    if (!Utility.IsMasterUser && Utility.UserId != this.id) throw new NoPermissionException();

                    // Chỉ có masterUser của masterClient mới được phép chỉnh sửa dữ liệu của user ở client khác
                    if (!Utility.IsMasterClient && !Utility.IsMasterUser && Utility.ClientId != this.clientId) throw new NoPermissionException();

                    // Nếu không phải là MasterUser thì không cho phép cập nhật isMaster, isActived
                    if (!Utility.IsMasterUser)
                    {
                        context.Entry(this).Property(x => x.isMaster).IsModified = false;
                        context.Entry(this).Property(x => x.isActivated).IsModified = false;
                    }

                    // Không cho phép cập nhật username
                    context.Entry(this).Property(x => x.username).IsModified = false;
                }
            }
        }
    }
}
