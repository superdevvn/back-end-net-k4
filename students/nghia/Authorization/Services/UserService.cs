using System;
using Models;
using Repositories;
using Services.Exceptions;
using Utilities;

namespace Services
{
    public class UserService : BaseService<User, UserRepository>
    {
        public User Login(string username, string password)
        {
            var user = First("Username", username);
            if (user.password != Utility.MD5Encrypt(password)) throw new WrongException("PASSWORD");
            if (!user.isActivated) throw new NotActiveException("USER");
            return user;
        }

        public override User Save(User entity, bool requireAuthorization = true)
        {
            if (entity.id == Guid.Empty)
            {
                entity.password = Utility.MD5Encrypt(entity.password);
            }
            else
            {
                var user = One(entity.id);
                if (!string.IsNullOrWhiteSpace(entity.password) && user.password != entity.password) entity.password = Utility.MD5Encrypt(entity.password);
            }
            return base.Save(entity, requireAuthorization);
        }

        public dynamic GetUserInfomation(Guid userId)
        {
            var clientService = ClientService.Instance;
            var user = One(userId);
            var client = clientService.One(user.clientId);
            var customIdentity = new CustomIdentity(client.id, client.code, client.isMaster, user.id, user.username, user.isMaster);
            var token = Utility.Encrypt(customIdentity);
            return new {
                token = token,
                id = user.id,
                clientId = client.id,
                clientCode = client.code,
                clientName = client.name,
                isMasterClient = client.isMaster,
                username = user.username,
                password = user.password,
                isActivated = user.isActivated,
                fullName = user.fullName,
                email = user.email,
                phone = user.phone,
                address = user.address,
                isMasterUser = user.isMaster
            };
        }

        public User ChangePassword(string oldPassword, string newPassword)
        {
            var user = One(Utility.UserId);
            if (!string.Equals(user.password, Utility.MD5Encrypt(oldPassword))) throw new Exception("WRONG PASSWORD");
            if(string.IsNullOrWhiteSpace(newPassword)) throw new Exception("NEW PASSWORD REQUIRED");
            user.password = Utility.MD5Encrypt(newPassword);
            return Update(user);
        }

        public string GenerateToken(Guid userId)
        {
            var clientService = ClientService.Instance;
            var user = One(userId);
            var client = clientService.One(user.clientId);
            var customIdentity = new CustomIdentity(client.id, client.code, client.isMaster, user.id, user.username, user.isMaster);
            return Utility.Encrypt(customIdentity);
        }
    }
}
