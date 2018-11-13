using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class TuNhienSubject : ISubject, IPrintSubject
    {
        public string MaMonHoc { get; set; }

        public int SoTinChi { get; set; }

        public void Print()
        {
            Console.WriteLine($"Mon Hoc: Tu Nhien, Ma Mon Hoc: {MaMonHoc}, So Tin Chi: {SoTinChi}");
        }
    }
}
