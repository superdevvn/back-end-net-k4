using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Student
    {
        public Guid Id { get; set; }

        [StringLength(20)]
        public string FirstName { get; set; }

        [StringLength(20)]//attribuite
        public string LastName { get; set; }
    }
}
