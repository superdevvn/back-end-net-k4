using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class XaHoiSubject : ISubject, IPrintSubject
    {
        public string MaMonHoc { get; set; }

        public int SoTinChi { get; set; }

        public void Print()
        {
            Console.WriteLine($"Mon Hoc: Xa Hoi, Ma Mon Hoc: {MaMonHoc}, So Tin Chi: {SoTinChi}");
        }
    }
}
