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
        public DbSet<User> Users { get; set; }
    }
    public class User: BaseEntity
    {
        [Required]
        [StringLength(50)]
        [Index("IX_Username", IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        public bool IsActivated { get; set; }
    }
}
