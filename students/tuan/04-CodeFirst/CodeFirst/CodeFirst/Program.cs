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
            //var student= GetList();
            //Print(student);
            // Print(GetList());
            Create();
            Console.ReadKey();
        }

        public static void Init()
        {
            using (var context = new SuperDevDbContext())
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
            using (var context = new SuperDevDbContext())
            {
                var student = new Student()
                {
                    Id = Guid.NewGuid(),
                    FirstName = firstName,
                    LastName = lastName,
                };
                context.Students.Add(student);
                context.SaveChanges();
            }
        }

        public static void Create()
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
                    Console.WriteLine("***********************************");
                }
                else
                {
                    //Print(GetList());
                   // Print(GetListFirsFirstNameIsMinh());
                    Console.WriteLine($"ID: {GetStudentFirstOrDefautIsMinh().Id}");
                    Console.WriteLine($"First Name: {GetStudentFirstOrDefautIsMinh().FirstName}");
                    Console.WriteLine($"Last Name: {GetStudentFirstOrDefautIsMinh().LastName}");
                    break;
                }
            }
        }


        public static List<Student> GetList()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Students.ToList();
            }
        }


        public static Student GetStudentFirstOrDefautIsMinh()
        {
            Console.WriteLine("Student have a first name is Minh");
            using (var context = new SuperDevDbContext())
            {
                return context.Students.FirstOrDefault(x => x.FirstName == "Minh");
            }
        }


        public static List<Student> GetListFirsFirstNameIsMinh()
        {
            Console.WriteLine("Students have a first name is Minh");
            using (var context = new SuperDevDbContext())
            {
                return context.Students.Where(x => x.FirstName == "Minh").ToList();
            }
        }

        //public static Student GetListCharactorLastNameIsT()
        //{
        //    using (var context = new SuperDevDbContext())
        //    {
                
        //    }
        //}

        public static void Print(List<Student> students)
        {
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}");
                Console.WriteLine($"Full Name: {student.FirstName} {student.LastName}");
                Console.WriteLine("-------------------------------");
            }
        }
    }
}
