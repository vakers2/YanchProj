using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(string id);

        User CheckUser(string login);

        List<User> GetUsers();

        void CreateUser(User user);

        void DeleteUser(User user);

        void UpdateUser(User user);
    }
}
