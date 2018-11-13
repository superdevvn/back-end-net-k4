using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TruuTuong.Interfaces;

namespace TruuTuong
{
    public class Handler<T>
        where T: ISubject, IPrintSubject
    {
        public void Print(T instance)
        {
            instance.Print();
        }
    }
}
