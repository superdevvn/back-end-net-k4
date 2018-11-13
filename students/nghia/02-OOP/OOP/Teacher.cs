using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class Teacher: Person
    {
        public Teacher(): base("Super", "Dev")
        {
            FirstName+= "01";
            LastName+= "01";
        }

        public Teacher(string firstName, string lastName) : base(firstName, lastName)
        {

        }

        public override void Hello()
        {
            // base.Hello();
            Console.WriteLine($"Hello Teacher {FirstName} {LastName}");
        }

        public override void Hello(string key)
        {
            // base.Hello(key);
            Console.WriteLine($"Hello Teacher {FirstName} {LastName}, {key}");
        }
    }
}
