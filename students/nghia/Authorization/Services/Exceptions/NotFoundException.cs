using System;

namespace Services.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("NOT FOUND") { }

        public NotFoundException(string title) : base($"{title} NOT FOUND") { }

        public NotFoundException(string entityName, string title) : base(string.Format($"[{entityName}] {title} NOT FOUND")) { }
    }
}
