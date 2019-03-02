using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class InvalidException : Exception
    {
        public InvalidException() : base("INVALID") { }

        public InvalidException(string title) : base(string.Format("{0} INVALID", title)) { }
    }
}
