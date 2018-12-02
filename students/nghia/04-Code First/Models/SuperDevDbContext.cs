using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SuperDevDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Subjects { get; set; }

        public SuperDevDbContext() 
            : base("Data Source=DESKTOP-15KKVN2\\SQLEXPRESS;Initial Catalog=SampleCodeFirst;Integrated Security=True;")
        {
        }
    }
}
