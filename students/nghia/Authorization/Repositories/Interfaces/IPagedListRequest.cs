using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface IPagedListRequest
    {
        string whereClause { get; set; }

        string orderBy { get; set; }

        string orderDirection { get; set; }

        int pageNumber { get; set; }

        int pageSize { get; set; }
    }
}
