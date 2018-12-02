using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class SuperDevDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Subject> Objects { get; set; } 

        public SuperDevDbContext() 
            : base("Data Source= MINHTUAN\\SQLEXPRES;Initial Catalog=SampleCodeFirst;Integrated Security=True;")
        {

        }
    }
}
