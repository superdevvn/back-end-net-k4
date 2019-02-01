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
        public DbSet<Claim> Claims { get; set; }
    }
    public class Claim: BaseEntity
    {
        [Required]
        [StringLength(20)]
        [Index("IX_Code", IsUnique = true)]
        public string Code { get; set; }

        [StringLength(50)]
        public string Name { get; set; }
    }
}
