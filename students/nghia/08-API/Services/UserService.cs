using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using Repositories;
using Utilities;

namespace Services
{
    public class UserService : BaseService<User, UserRepository>
    {
        public override User Create(User entity)
        {
            entity.Password = Utility.MD5(entity.Password);
            if (HasUsername(entity.Username)) throw new Exception("USERNAME EXISTED");
            return base.Create(entity);
        }

        public override User Update(User entity)
        {
            var user = Get(entity.Id);
            if (user == null) throw new Exception("USER NOT FOUND");
            if (user.Password != entity.Password) entity.Password = Utility.MD5(entity.Password);
            return base.Update(entity);
        }

        public User Login(string username, string password)
        {
            var user = repository.Get($"Username = \"{username}\"");
            if (user == null) throw new Exception("USERNAME NOT FOUND");
            if (user.Password != Utility.MD5(password)) throw new Exception("INCORECT PASSWORD");
            if (!user.IsActivated) throw new Exception("USER INACTIVATED");
            return user;
        }

        private bool HasUsername(string username)
        {
            var user = repository.Get($"Username = \"{username}\"");
            return user != null;
        }
    }
}
