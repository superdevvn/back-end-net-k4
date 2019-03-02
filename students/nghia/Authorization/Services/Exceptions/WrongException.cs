using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class WrongException: Exception
    {
        public WrongException() : base("WRONG") { }

        public WrongException(string title) : base(string.Format("WRONG {0}", title)) { }
    }
}
