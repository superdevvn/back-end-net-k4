using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // DongGoi();
            // KeThua();
            DaHinh();
        }

        static void DongGoi()
        {
            Person person = new Person("Super", "Dev");
            person.Hello();
        }

        static void KeThua()
        {
            Teacher teacher1 = new Teacher();
            Teacher teacher2 = new Teacher("Nghia", "Tran");
            teacher1.Hello();
            teacher2.Hello();
        }

        static void DaHinh()
        {
            List<Person> persons = new List<Person>();
            Person person = new Person("Tuan", "Tran");
            Teacher teacher = new Teacher("Nghia", "Tran");
            persons.Add(person);
            persons.Add(teacher);
            foreach (var item in persons) item.Hello("NET");
        }
    }
}
