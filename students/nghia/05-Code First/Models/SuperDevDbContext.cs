using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public partial class SuperDevDbContext: DbContext
    {
        public SuperDevDbContext()
            : base("Data Source=DESKTOP-15KKVN2\\SQLEXPRESS;Initial Catalog=SampleRepository;Integrated Security=True;")
        {
        }
    }
}
