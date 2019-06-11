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
        GetUserViewModel GetUser(string id);

        GetUserViewModel GetUserByLogin(string login);

        List<GetUserViewModel> GetUsers();

        GetUserViewModel CreateUser(CreateUserViewModel user);

        void DeleteUser(string id);

        void UpdateUser(GetUserViewModel user);

        void UpdateUserStatus(string id, UserStatus status);

        GetUserViewModel CheckUser(LogInUserViewModel credentials);
    }
}
