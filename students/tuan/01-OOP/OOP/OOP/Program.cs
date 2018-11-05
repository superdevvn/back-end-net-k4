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
            //DongGoi();
            //KeThua();
            DaHinh();
            Console.ReadKey();
        }

        static void DongGoi()
        {
            Person person = new Person("Minh", "Tuan");
            person.Hello();
        }

        //static void KeThua()
        //{
        //    Teacher teacher1 = new Teacher();
        //    Teacher teacher2 = new Teacher("Super", "Dev");
        //    teacher1.Hello();
        //    teacher2.Hello();
        //}

        static void DaHinh()
        {
            List<Person> persons = new List<Person>();
            Person person = new Person("Tuan", "Tran");
            Teacher teacher = new Teacher("Nghia", "Tran");
            Worker worker = new Worker("Hung", "Dung");
            persons.Add(person);
            persons.Add(teacher);
            persons.Add(worker);
            foreach (var item in persons)
            {
                int salary = item.BaseSalary();
                if (item == person)
                {
                    Console.WriteLine($"Salary of Person is {salary} and CaculatorSalary is {item.CaculatorSalary()}");
                }
                else if(item == teacher)
                {
                    Console.WriteLine($"Salary of Teacher is {salary} and CaculatorSalary is {item.CaculatorSalary()}");
                }
                else
                {
                    Console.WriteLine($"Salary of Worker is {salary} and CaculatorSalary is {item.CaculatorSalary()}");
                }
            }
                
        }
    }
}
