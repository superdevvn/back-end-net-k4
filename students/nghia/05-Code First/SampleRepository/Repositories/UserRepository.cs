using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Repositories
{
    public class UserRepository
    {
        public User Create(User user)
        {
            using (var context = new SuperDevDbContext())
            {
                user.Id = Guid.NewGuid();
                context.Users.Add(user);
                context.SaveChanges();
                return context.Users.Find(user.Id);
            }
        }

        public User Update(User user)
        {
            using (var context = new SuperDevDbContext())
            {
                User userInDB = context.Users.Find(user.Id);
                userInDB.Username = user.Username;
                userInDB.Password = user.Password;
                userInDB.IsActived = user.IsActived;
                context.SaveChanges();
                context.Entry(userInDB).Reload();
                return userInDB;
            }
        }

        public void Delete(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                User userInDB = context.Users.Find(id);
                context.Users.Remove(userInDB);
                context.SaveChanges();
            }
        }

        public User Get(Guid id)
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Users.Find(id);
            }
        }

        public List<User> List()
        {
            using (var context = new SuperDevDbContext())
            {
                return context.Users.ToList();
            }
        }
    }
}
