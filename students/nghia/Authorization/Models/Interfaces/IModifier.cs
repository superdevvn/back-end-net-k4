using System;

namespace Models.Interfaces
{
    public interface IModifier
    {
        Guid? modifiedBy { get; set; }

        DateTime modifiedDate { get; set; }

        string modifier { get; set; }
    }
}