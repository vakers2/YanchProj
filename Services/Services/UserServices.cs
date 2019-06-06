using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;
using Models.ViewModels;
using Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Services.Helpers;

namespace Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public GetUserViewModel CreateUser(CreateUserViewModel user)
        {
            if (userRepository.GetUsers().Exists(x => x.Login == user.Login))
            {
                return null;
            }

            var newUser = Mapper.Map<CreateUserViewModel, User>(user);
            newUser.Password = UserHelper.ComputePasswordHash(newUser.Password);
            userRepository.CreateUser(newUser);

            return Mapper.Map<GetUserViewModel>(userRepository.GetUser(user.Login));
        }

        public void DeleteUser(int id)
        {
            var user = userRepository.GetUser(id);
            if (user != null)
            {
                userRepository.DeleteUser(user);
            }
        }

        public GetUserViewModel GetUser(int id)
        {
            return Mapper.Map<User, GetUserViewModel>(userRepository.GetUser(id));
        }

        public GetUserViewModel GetUser(string login)
        {
            return Mapper.Map<User, GetUserViewModel>(userRepository.GetUser(login));
        }

        public List<GetUserViewModel> GetUsers()
        {
            return userRepository.GetUsers().Select(Mapper.Map<User, GetUserViewModel>).ToList();
        }

        public void UpdateUser(GetUserViewModel user)
        {
            userRepository.UpdateUser(Mapper.Map<GetUserViewModel, User>(user));
        }

        public void UpdateUserStatus(int id, UserStatus status)
        {
            var user = userRepository.GetUser(id);
            if (user != null)
            {
                user.Status = status;
                userRepository.UpdateUser(user);
            }
        }

        public GetUserViewModel CheckUser(LogInUserViewModel credentials)
        {
            var user = userRepository.GetUser(credentials.Login);
            if (user != null && (user.Password == UserHelper.ComputePasswordHash(credentials.Password) &&
                (user.Status != UserStatus.Pending || user.Status != UserStatus.Blocked)))
            {
                return Mapper.Map<GetUserViewModel>(user);
            }

            return null;
        }
    }
}
