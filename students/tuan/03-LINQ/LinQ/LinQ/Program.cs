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

            //Print(stuents);
            // Print(LayNhungStudentHoTran(students));
            //Print(LayNhungStudentScoreLonHon7(students));
            // Print(LayNhungStudentSinhVaoThang8(students));
            var student = StudentDauTienHoTran(students);
            Console.WriteLine($"FirstName: {student.FirstName} - LastName: {student.LastName} - {student.Score} - {student.Birthday.ToString("dd/MM/yyyy")}");
           // Print(SapXepStudentTheoDiemSo(students));
            Console.ReadKey();
        }

        static void Print(List<Student> students)
        {
            Console.WriteLine($"List stuents");
            foreach (var item in students)
            {
                Console.WriteLine($"{item.FirstName} {item.LastName} - {item.Score} - {item.Birthday.ToString("dd/MM/yyyy")}");
            }
        }

        static List<Student> Init()
        {
            List<Student> students = new List<Student>();

            students.Add(new Student()
            {
                FirstName = "Tran",
                LastName = "Tuan",
                Score = 6,
                Birthday = new DateTime(1994, 05, 31),
            });

            students.Add(new Student()
            {
                FirstName = "Do",
                LastName = "Huy",
                Score = 8,
                Birthday = new DateTime(1994, 8, 28),
            });

            students.Add(new Student()
            {
                FirstName = "Tran",
                LastName = "Diem",
                Score = 10,
                Birthday = new DateTime(1993, 04, 18),
            });

            students.Add(new Student()
            {
                FirstName = "Tran",
                LastName = "Trang",
                Score = 7,
                Birthday = new DateTime(1996, 8, 20),
            });

            return students;
        }

        static List<Student> LayNhungStudentHoTran(List<Student> students)
        {
            //return students.Where(x =>
            //{
            //    if (x.FirstName == "Tran") return true;
            //    else return false;
            //}).ToList();

            //return students.Where(x =>
            //{
            //    return x.FirstName == "Tran";
            //}).ToList();

            return students.Where(x => x.FirstName == "Tran").ToList();

        }

        static List<Student> LayNhungStudentScoreLonHon7(List<Student> students)
        {
            return students.Where(x => x.Score > 7).ToList();
        }

        static List<Student> LayNhungStudentSinhVaoThang8(List<Student> students)
        {
            return students.Where(x => x.Birthday.Month == 8).ToList();
        }

        static Student StudentDauTienHoTran(List<Student> students)
        {
            return students.FirstOrDefault(x => x.FirstName == "Tran");
        }

        static List<Student> SapXepStudentTheoDiemSo(List<Student> students)
        {
            //return students.OrderBy(x => x.Score).ToList();
            return students.OrderBy(x => x.Score).ThenBy(x => x.LastName).ToList();
        }
    }
}
//Về tìm hiểu thêm Content
// where
//OrderBy
//Skip
//Take