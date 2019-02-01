using System.Web.Http;
using Models;
using Newtonsoft.Json.Linq;
using Repositories;
using Services;

namespace Controllers
{
    [RoutePrefix("api/role")]
    public class RoleApiController : BaseApiController<Role, RoleRepository, RoleService>
    {
    }
}
