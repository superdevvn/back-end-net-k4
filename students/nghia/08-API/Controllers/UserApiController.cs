using System.Web.Http;
using Models;
using Newtonsoft.Json.Linq;
using Repositories;
using Services;

namespace Controllers
{
    [RoutePrefix("api/user")]
    public class UserApiController : BaseApiController<User, UserRepository, UserService>
    {
        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(JObject json)
        {
            string username = json.GetValue("username").ToString();
            string password = json.GetValue("password").ToString();
            return Ok(service.Login(username, password));
        }
    }
}
