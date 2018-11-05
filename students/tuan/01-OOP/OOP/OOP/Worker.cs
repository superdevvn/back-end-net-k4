using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Worker : Person
    {

        public Worker(string firstName, string lastName) : base(firstName, lastName)
        {
            FirstName = firstName;
            LastName = LastName;
        }

        public override void Hello()
        {
            Console.WriteLine($"Hello Worker: {FirstName} {LastName}");
        }

        public override int BaseSalary()
        {
            return base.BaseSalary() + 5;
        }

        public override int CaculatorSalary()
        {
            return base.CaculatorSalary() * 2;
        }
    }
}
