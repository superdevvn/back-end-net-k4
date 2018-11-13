using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruuTuong
{
    class Program
    {
        static void Main(string[] args)
        {
            //Handler handler = new Handler();
            //Testing testing = new Testing();
            //testing.TestSum(handler);
            //testing.TestMin(handler);
            //char x = 'A';
            //char y = 'B';
            //char a = 'A';
            //char b = 'B';
            //char x1 = x;
            //char y1 = y;

            //unsafe
            //{
            //    int* p = &x;
            //    Console.WriteLine((int)p);
            //}

            //Console.WriteLine(x == a);
            //Test(x, y);
            //Console.WriteLine(x);
            //Console.WriteLine(y);

            var tuNhienSubject1 = new TuNhienSubject()
            {
                MaMonHoc = "TN001",
                SoTinChi = 4
            };

            var tuNhienSubject2 = new TuNhienSubject()
            {
                MaMonHoc = "TN001",
                SoTinChi = 4
            };

            var tuNhienSubject3 = tuNhienSubject1;

            Console.WriteLine(tuNhienSubject1 == tuNhienSubject2);
            Console.WriteLine(tuNhienSubject1 == tuNhienSubject3);
            tuNhienSubject2 = tuNhienSubject3;
            Console.WriteLine(tuNhienSubject1 == tuNhienSubject2);
        }

        static void Test(char x, char y)
        {
            x = 'X';
            y = 'Y';
        }
    }
}
