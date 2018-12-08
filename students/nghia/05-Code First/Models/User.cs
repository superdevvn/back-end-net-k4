using System;
using System.Collections.Generic;
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
    public class User
    {
        public Guid Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsActived { get; set; }
    }
}
