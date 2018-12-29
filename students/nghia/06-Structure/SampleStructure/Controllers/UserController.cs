using System.Web.Http;
using Models;
using Repositories;

namespace SampleStructure.Controllers
{
    public class UserController : ApiController
    {
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult Create(User user)
        {
            var userRepository = new UserRepository();
            user = userRepository.Create(user);
            return Ok(user);
        }

        [HttpPost]
        [Route("api/user/update")]
        public IHttpActionResult Update(User user)
        {
            var userRepository = new UserRepository();
            user = userRepository.Update(user);
            return Ok(user);
        }
    }
}