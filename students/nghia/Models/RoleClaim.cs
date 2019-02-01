using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class SuperDevDbContext
    {
        public DbSet<RoleClaim> RoleClaims { get; set; }
    }
    public class RoleClaim : BaseEntity
    {
        public Guid RoleId { get; set; }

        public Guid ClaimId { get; set; }

        [StringLength(10)]
        public string Permission { get; set; }

        // Định nghĩa ràng buộc
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [ForeignKey("ClaimId")]
        public virtual Claim Claim { get; set; }
    }

    public enum Permission
    {
        READ,
        CREATE,
        EDIT,
        DELETE
    }
}
