using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Models.Interfaces
{
    public interface IBeforeSave
    {
        void BeforeSave(DbContext context, DbEntityEntry entry, bool requireAuthorization = true);
    }
}
