using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruuTuong.Interfaces
{
    public interface IExcute<T>
        where T: ISubject, IPrintSubject
    {
        void Print(T instance);
    }
}
