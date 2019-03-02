using System;

namespace Models.Interfaces
{
    public interface IApprover
    {
        Guid? approvedBy { get; set; }

        DateTime? approvedDate { get; set; }

        string approver { get; set; }
    }
}
