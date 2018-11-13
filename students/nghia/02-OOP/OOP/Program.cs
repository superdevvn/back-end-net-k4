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
            //DaHinh();
            TruuTuong();
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

        static void InDanhSachMonHoc(List<ISubject> subjects)
        {
            //foreach (var subject in subjects)
            //{
            //    if(subject is TuNhienSubject) Console.WriteLine($"Mon Hoc: Tu Nhien, Ma Mon Hoc: {subject.MaMonHoc}, So Tin Chi: {subject.SoTinChi}");
            //    else if (subject is XaHoiSubject) Console.WriteLine($"Mon Hoc: Xa Hoi, Ma Mon Hoc: {subject.MaMonHoc}, So Tin Chi: {subject.SoTinChi}");
            //}
            foreach (var subject in subjects)
            {
                if (subject is IPrintSubject) (subject as IPrintSubject).Print();
                else Console.WriteLine($"Ma Mon Hoc: {subject.MaMonHoc}, So Tin Chi: {subject.SoTinChi}");
            }
        }

        static void TruuTuong()
        {
            var tuNhienSubject = new TuNhienSubject()
            {
                MaMonHoc = "TN001",
                SoTinChi = 4
            };

            var xaHoiSubject = new XaHoiSubject()
            {
                MaMonHoc = "XH001",
                SoTinChi = 4
            };

            List<ISubject> subjects = new List<ISubject>();
            subjects.Add(tuNhienSubject);
            subjects.Add(xaHoiSubject);
            InDanhSachMonHoc(subjects);
        }
    }
}
