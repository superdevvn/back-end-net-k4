using System;
using TruuTuong.Interfaces;

namespace TruuTuong
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
