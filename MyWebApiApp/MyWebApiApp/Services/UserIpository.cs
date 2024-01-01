using MyWebApiApp.Data;
using MyWebApiApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWebApiApp.Services
{
    public class UserIpository : IUserRepository
    {
        private readonly MyDbContext _context;

        public UserIpository(MyDbContext context) {
            _context = context;
        }
        public UserModel Add(UserModel model)
        {
            var user = new User
            {
                user_name = model.user_name,
                password = model.password,
            };
            _context.Add(user);
            _context.SaveChanges();
            return new UserModel
            {
                user_name = user.user_name,
                password = user.password,
            };
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.user_id == id);
            if (user == null)
            {
            }
            _context.Remove(user);
            _context.SaveChanges();
        }

        public List<UserModel> GetAll()
        {
            var list = _context.Users.Select(u => new UserModel
            {
                user_id = u.user_id,
                user_name = u.user_name,
            });
            return list.ToList();
        }

        public UserModel GetById(Guid id)
        {
            var user = _context.Users.SingleOrDefault(u => u.user_id == id);
            if (user == null)
            {
                return null;
            }
            return new UserModel
            {
                user_id = user.user_id,
                user_name = user.user_name,
            };
        }
    }
}
