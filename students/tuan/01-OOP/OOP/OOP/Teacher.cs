using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Teacher: Person
    {

        public Teacher() : base("Minh", "Tuan")
        {
            FirstName += "01";
            LastName += "01";
        }

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public override void Hello()
        {
            //base.Hello();
            Console.WriteLine($"Hello Teacher {LastName} {FirstName}");
        }

        public override int BaseSalary()
        {
            return base.BaseSalary() + 10;
        }

        public override int CaculatorSalary()
        {
            return base.CaculatorSalary() * 3;
        }
    }
}
