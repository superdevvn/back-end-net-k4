using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruuTuong.Interfaces;

namespace TruuTuong
{
    public class Testing
    {
        //public void TestSum(ISum instance)
        //{
        //    if (instance.Sum(5, 2) == 7) Console.WriteLine("Sum Success");
        //    else Console.WriteLine("Sum Fail");
        //}

        public void TestMin(IMin instance)
        {
            int[] mangSoNguyen = new int[] { 5, 2, -1, 9 };
            //List<int> mangSoNguyen = new List<int>();
            //mangSoNguyen.Add(5);
            //mangSoNguyen.Add(2);
            //mangSoNguyen.Add(-1);
            //mangSoNguyen.Add(9);
            if (instance.Min(mangSoNguyen) == -1) Console.WriteLine("Min Success");
            else Console.WriteLine("Min Fail");
        }

        public void TestExcute()
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

            var handerTuNhien = new Handler<TuNhienSubject>();
            handerTuNhien.Print(tuNhienSubject);

            var handerXaHoi = new Handler<XaHoiSubject>();
            handerXaHoi.Print(xaHoiSubject);
        }
    }
}
