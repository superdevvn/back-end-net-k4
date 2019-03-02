using System;

namespace Models.Exceptions
{
    public class NoPermissionException: Exception
    {
        public NoPermissionException() : base("NO PERMISSION") { }
    }
}
