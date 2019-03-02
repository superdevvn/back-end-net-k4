using System.Collections;
using Repositories.Interfaces;

namespace Repositories.Commons
{
    public class PagedListResult: IPagedListResult
    {
        public int total { get; set; }
        public IEnumerable items { get; set; }

        public PagedListResult(IEnumerable items, int total)
        {
            this.items = items;
            this.total = total;
        }
    }
}
