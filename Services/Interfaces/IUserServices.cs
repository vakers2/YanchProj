using System.Collections.Generic;
using Entities.Enums;
using Models.ViewModels.User;

namespace Services.Interfaces
{
    public interface IUserServices
    {
        GetUserViewModel GetUser(string id);

        GetUserViewModel GetUserByLogin(string login);

        List<GetUserViewModel> GetUsers();

        List<GetUserAdminViewModel> GetFullUsers();

        GetUserViewModel CreateUser(CreateUserViewModel user);

        void DeleteUser(string id);

        void UpdateUser(GetUserViewModel user);

        void UpdateUserStatus(string id, UserStatus status);

        GetUserViewModel CheckUser(LogInUserViewModel credentials);
    }
}
