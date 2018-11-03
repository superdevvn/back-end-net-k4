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

        public Person(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public virtual void Hello()
        {
            Console.WriteLine($"Hello {FirstName} {LastName}");
        }

        public virtual void Hello(string key)
        {
            Console.WriteLine($"Hello {FirstName} {LastName}, {key}");
        }
    }
}
