using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using AutoMapper;
using Models.ViewModels;
using Services.Interfaces;
using DAL.Interfaces;
using Entities.Entities;
using Entities.Enums;
using Models.ViewModels.Post;

namespace Services.Services
{
    public class PostServices : IPostServices
    {
        private readonly IPostRepository postRepository;

        public PostServices(IPostRepository postRepository)
        {
            this.postRepository = postRepository;
        }

        public GetPostViewModel CreatePost(CreatePostViewModel post, string ownerId)
        {
            var newPost = Mapper.Map<CreatePostViewModel, Post>(post);
            newPost.CreationDate = DateTime.Now;
            newPost.OwnerId = ownerId;

            return Mapper.Map<GetPostViewModel>(postRepository.CreatePost(newPost));
        }

        public void DeletePost(string id)
        {
            var post = postRepository.GetPost(id);
            if (post != null)
            {
                postRepository.DeletePost(post);
            }
        }

        public GetPostViewModel GetPost(string id)
        {
            return Mapper.Map<Post, GetPostViewModel>(postRepository.GetPost(id));
        }

        public List<GetPostViewModel> GetPosts()
        {
            return postRepository.GetPosts().Select(Mapper.Map<Post, GetPostViewModel>).ToList();
        }

        public void UpdatePost(GetPostViewModel post)
        {
            postRepository.UpdatePost(Mapper.Map<GetPostViewModel, Post>(post));
        }
    }
}
