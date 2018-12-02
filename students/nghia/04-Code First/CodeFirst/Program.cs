using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            Create();
        }

        static void CreateStudent(string firstName, string lastName)
        {
            using (var context = new SuperDevDbContext())
            {
                var student = new Student()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        static void Print(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}");
                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"*********************************************");
            }
        }

        static List<Student> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Students.ToList();
            }
        }

        static void Create()
        {
            while (true)
            {
                Console.Write("Do you want to add new student, Y/N?: ");
                if (Console.ReadLine() == "Y")
                {
                    Console.Write("Enter First Name: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Enter Last Name: ");
                    string lastName = Console.ReadLine();
                    CreateStudent(firstName, lastName);
                    Console.WriteLine("*************************************");
                }
                else
                {
                    Print(GetList());
                    break;
                }
            }
        }
    }
}
