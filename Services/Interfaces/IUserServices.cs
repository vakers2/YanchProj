using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;
using Entities.Enums;
using Models.ViewModels;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        GetUserViewModel GetUser(int id);

        GetUserViewModel GetUser(string login);

        List<GetUserViewModel> GetUsers();

        GetUserViewModel CreateUser(CreateUserViewModel user);

        void DeleteUser(int id);

        void UpdateUser(GetUserViewModel user);

        void UpdateUserStatus(int id, UserStatus status);

        GetUserViewModel CheckUser(LogInUserViewModel credentials);
    }
}
