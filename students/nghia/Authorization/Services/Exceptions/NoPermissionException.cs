using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Exceptions
{
    public class NoPermissionException : Exception
    {
        public NoPermissionException() : base("NO PERMISSION") { }

        public NoPermissionException(string title) : base(string.Format("NO PERMISSION {0}", title)) { }
    }
}
