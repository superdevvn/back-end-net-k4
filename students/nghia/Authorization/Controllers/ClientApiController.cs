using System.Web.Http;
using Models;
using Repositories;
using Services;

namespace Controllers
{
    [RoutePrefix("api/client")]
    public class ClientApiController : BaseApiController<Client, ClientRepository, ClientService>
    {

    }
}