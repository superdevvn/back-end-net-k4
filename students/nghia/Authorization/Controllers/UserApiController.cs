using System.Web.Http;
using Models;
using Newtonsoft.Json.Linq;
using Repositories;
using Services;
using Utilities;

namespace Controllers
{
    [RoutePrefix("api/user")]
    public class UserApiController : BaseApiController<User, UserRepository, UserService>
    {
        [HttpPost]
        [Route("login")]
        public virtual IHttpActionResult Login(JObject json)
        {
            string username = json.GetValue("username").ToString();
            string password = json.GetValue("password").ToString();
            User user = service.Login(username, password);
            return Ok(service.GetUserInfomation(user.id));
        }

        [HttpGet]
        [Route("jwtconfiguration")]
        public virtual IHttpActionResult JwtConfiguration()
        {
            return Ok(new
            {
                SymmetricKey = JWT.Secret,
                Keys = CustomIdentity.Keys
            });
        }

        [HttpPost]
        [Route("authenticate")]
        public virtual IHttpActionResult AuthenticateJwtToken()
        {
            return Ok(service.GetUserInfomation(Utility.UserId));
        }

        [HttpPost]
        [Route("changePassword")]
        public virtual IHttpActionResult ChangePassword(JObject json)
        {
            string oldPassword = json.GetValue("oldPassword").ToString();
            string newPassword = json.GetValue("newPassword").ToString();
            return Ok(service.ChangePassword(oldPassword, newPassword));
        }
    }
}