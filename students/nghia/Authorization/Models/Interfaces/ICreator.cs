using System;

namespace Models.Interfaces
{
    public interface ICreator
    {
        Guid? createdBy { get; set; }

        DateTime createdDate { get; set; }

        string creator { get; set; }
    }
}
