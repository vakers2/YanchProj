using System;
using System.Collections.Generic;
using System.Text;
using Entities.Entities;
using Entities.Enums;
using Models.ViewModels;
using Models.ViewModels.Post;

namespace Services.Interfaces
{
    public interface IPostServices
    {
        GetPostViewModel GetPost(string id);

        List<GetPostViewModel> GetPosts();

        GetPostViewModel CreatePost(CreatePostViewModel post, string ownerId);

        void DeletePost(string id);

        void UpdatePost(GetPostViewModel post);
    }
}
