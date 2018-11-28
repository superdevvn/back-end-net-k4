using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var stuents = Init();
            Print(stuents);
            Console.ReadKey();
        }

        static void Print(List<Student> students)
        {
            Console.WriteLine($"List stuents");
            foreach(var item in students)
            {
                Console.WriteLine($"{item.FirstName} - {item.LastName} - {item.Score} - {item.Birthday}");
            }
        }

        static List<Student> Init()
        {
            List<Student> students = new List<Student>();

           students.Add( new Student()
            {
                FirstName = "Minh",
                LastName = "Tuan",
                Score = 6,
                Birthday = new DateTime(1994-05-31),
            });

            students.Add(new Student()
            {
                FirstName = "Khac",
                LastName = "Huy",
                Score = 8,
                Birthday = new DateTime(1994 - 05 - 28),
            });

            students.Add(new Student()
            {
                FirstName = "Thanh",
                LastName = "Diem",
                Score = 10,
                Birthday = new DateTime(1993 - 04 - 18),
            });

            return students;
        }
    }
}
