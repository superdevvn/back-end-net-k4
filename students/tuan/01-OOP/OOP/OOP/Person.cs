using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Person
    {
        protected string FirstName { get; set; }
        protected string LastName { get; set; }

        public Person() { }

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void Hello()
        {
            Console.WriteLine($"Hello {FirstName} {LastName}");
        }

        public virtual int BaseSalary()
        {
            return 2;
        }

        public virtual int CaculatorSalary()
        {
            return BaseSalary() * 1;
        }
    }
}
