using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Interfaces;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly Context context;

        public PostRepository(Context context)
        {
            this.context = context;
        }

        public Post CreatePost(Post post)
        {
            post.PostId = Guid.NewGuid().ToString();
            context.Posts.Add(post);
            context.SaveChanges();

            return post;
        }

        public void DeletePost(Post post)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public Post GetPost(String id)
        {
            return context.Posts.Include(x => x.Owner).SingleOrDefault(x => x.PostId == id);
        }

        public List<Post> GetPosts()
        {
            return context.Posts.Include(x => x.Owner).Reverse().ToList();
        }

        public void UpdatePost(Post post)
        {
            context.Posts.Update(post);
            context.SaveChanges();
        }
    }
}
