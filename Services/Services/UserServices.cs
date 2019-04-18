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

namespace Services.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository userRepository;

        public UserServices(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public void CreateUser(CreateUserViewModel user)
        {
            var newUser = Mapper.Map<CreateUserViewModel, User>(user);
            newUser.Password = UserHelper.ComputePasswordHash(newUser.Password);

            userRepository.CreateUser(newUser);
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
            user.Status = status;
            userRepository.UpdateUser(user);
        }
    }
}
