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
            var students = Init();
            // Print(students);
            Print(LayNhungStudentHoNguyen(students));
        }
        static List<Student> Init()
        {
            List<Student> students = new List<Student>();
            students.Add(new Student { FirstName = "Nghia", LastName = "Tran", Score = 10, Birthday = new DateTime(1991, 8, 22) });
            students.Add(new Student { FirstName = "Tuan", LastName = "Nguyen", Score = 8, Birthday = new DateTime(1994, 5, 15) });
            students.Add(new Student { FirstName = "Cuong", LastName = "Nguyen", Score = 6, Birthday = new DateTime(1997, 6, 20) });
            students.Add(new Student { FirstName = "Dong", LastName = "Xuan", Score = 4, Birthday = new DateTime(1994, 3, 5) });
            return students;
        }

        static void Print(List<Student> students)
        {
            foreach(var student in students)
            {
                Console.WriteLine($"First Name: {student.FirstName}");
                Console.WriteLine($"Last Name: {student.LastName}");
                Console.WriteLine($"Score: {student.Score}");
                Console.WriteLine($"Birthday: {student.Birthday.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"*********************************************");
            }
        }

        static List<Student> LayNhungStudentHoNguyen(List<Student> students)
        {
            //return students.Where(student =>
            //{
            //    if (student.LastName == "Nguyen") return true;
            //    else return false;
            //}).ToList();

            //return students.Where(student =>
            //{
            //    return student.LastName == "Nguyen";
            //}).ToList();

            // Lambda Expression
            return students.Where(student => student.LastName == "Nguyen").ToList();
        }

        static List<Student> LayNhungStudentScoreLonHon7(List<Student> students)
        {

        }

        static List<Student> LayNhungStudentSinhVaoThang8(List<Student> students)
        {

        }

        static Student StudentDauTienHoNguyen(List<Student> students)
        {
            // return students.FirstOrDefault(student => student.LastName == "Nguyen");
            return students.Where(student => student.LastName == "Nguyen").FirstOrDefault();
        }

        static List<Student> SapXepStudentTheoDiemSoTangDan(List<Student> students)
        {
            // return students.FirstOrDefault(student => student.LastName == "Nguyen");
            return students.OrderBy(e => e.Score).ThenBy(e => e.FirstName).ToList();
        }
    }
}
