using MyWebApiApp.Models;
using System;
using System.Collections.Generic;

namespace MyWebApiApp.Services
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetById(Guid id);
        UserModel Add(UserModel model);
        void Delete(Guid id);
    }
}
