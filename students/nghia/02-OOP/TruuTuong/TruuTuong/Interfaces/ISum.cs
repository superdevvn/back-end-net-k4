using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruuTuong.Interfaces
{
    public interface ISum<T>
    {
        T Sum(T a, T b);
    }
}
