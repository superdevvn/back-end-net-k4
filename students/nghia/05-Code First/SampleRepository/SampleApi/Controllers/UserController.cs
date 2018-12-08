using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Models;
using Repositories;

namespace SampleApi.Controllers
{
    public class UserController: ApiController
    {
        [HttpPost]
        [Route("api/user/create")]
        public IHttpActionResult Create(User user)
        {
            var userRepository = new UserRepository();
            return Ok(userRepository.Create(user));
        }

        [HttpGet]
        [Route("api/user/get")]
        public IHttpActionResult Get(Guid id)
        {
            var userRepository = new UserRepository();
            var user = userRepository.Get(id);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}