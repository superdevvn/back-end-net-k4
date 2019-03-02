using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class NotActiveException : Exception
    {
        public NotActiveException() : base("NOT ACTIVE") { }

        public NotActiveException(string title) : base(string.Format("{0} NOT ACTIVE", title)) { }
    }
}
