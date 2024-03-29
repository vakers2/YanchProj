﻿using System.Collections.Generic;
using Entities.Entities;

namespace DAL.Interfaces
{
    public interface IPostRepository
    {
        Post GetPost(string id);

        List<Post> GetPosts();

        Post CreatePost(Post user);

        void DeletePost(Post user);

        void UpdatePost(Post user);
    }
}