using System;

namespace Models.Interfaces
{
    public interface IDeletor
    {
        Guid? deletedBy { get; set; }

        DateTime deletedDate { get; set; }

        string deletor { get; set; }
    }
}