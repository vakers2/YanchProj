﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using Entities.Entities;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context context;

        public UserRepository(Context context)
        {
            this.context = context;
        }

        public void CreateUser(User user)
        {
            user.UserId = Guid.NewGuid().ToString();
            context.Users.Add(user);
            context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            context.Users.Remove(user);
            context.SaveChanges();
        }

        public User GetUser(string id)
        {
            return context.Users.SingleOrDefault(x => x.UserId == id);
        }

        public User CheckUser(string login)
        {
            return context.Users.SingleOrDefault(x => x.Login == login);
        }

        public List<User> GetUsers()
        {
            return context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            context.Users.Update(user);
            context.SaveChanges();
        }
    }
}
