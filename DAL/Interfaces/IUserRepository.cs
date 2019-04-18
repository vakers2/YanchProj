using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IUserRepository
    {
        User GetUser(int id);

        List<User> GetUsers();

        void CreateUser(User user);

        void DeleteUser(User user);

        void UpdateUser(User user);
    }
}
