using System.Collections;

namespace Repositories.Interfaces
{
    public interface IPagedListResult
    {
        int total { get; set; }
        IEnumerable items { get; set; }
    }
}
