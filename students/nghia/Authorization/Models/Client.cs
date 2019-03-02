using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Models.Attributes;
using Models.Commons;
using Models.Exceptions;
using Models.Interfaces;
using Utilities;

namespace Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<Client> Clients { get; set; }
    }

    [MasterClientPermission]
    [MasterUserPermission]
    public class Client : BaseEntity, IBeforeSave
    {
        [StringLength(20)]
        [Index("IX_Code", IsUnique = true)]
        public string code { get; set; }

        [StringLength(200)]
        public string name { get; set; }

        [StringLength(20)]
        public string phone { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(1000)]
        public string description { get; set; }

        public bool isMaster { get; set; }

        public void BeforeSave(DbContext context, DbEntityEntry entry, bool requireAuthorization = true)
        {
            if(entry.State == EntityState.Added)
            {
                clientId = id;
                clientCode = code;
            }
            
            if (requireAuthorization)
            {
                // Chỉ có masterUser của masterClient mới được tạo mới/chỉnh sửa dữ liệu client
                if (!Utility.IsMasterUser || !Utility.IsMasterClient) throw new NoPermissionException();
            }
        }
    }
}
