using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            var student= GetList();
            Print(student);
            Console.ReadKey();
        }

        public static void Init()
        {
            using(var context = new SuperDevDbContext())
            {
                var student = new Student()
                {
                    Id = Guid.NewGuid(),
                    FirstName = "Minh",
                    LastName = "Tuan",
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public static void CreateStudent(string firstName, string lastName)
        {

        }

        public static List<Student> GetList()
        {
            using(var context = new SuperDevDbContext())
            {
                return context.Students.ToList();
            }
        }

        public static void Print(List<Student> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"Id: {student.Id}");
                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
            }
        }
    }
}
