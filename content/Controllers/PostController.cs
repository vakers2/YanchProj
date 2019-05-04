using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Models.ViewModels.Post;
using Services.Interfaces;

namespace Vue2Spa.Controllers
{
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostServices postServices;
        private readonly IUserServices userServices;

        public PostController(IPostServices postServices, IUserServices userServices)
        {
            this.postServices = postServices;
            this.userServices = userServices;
        }

        [HttpGet]
        [Route("/post/getall")]
        public IActionResult GetAll()
        {
            return Ok(postServices.GetPosts());
        }

        [Authorize]
        [HttpPost]
        [Route("/post/create")]
        public IActionResult Create([FromBody]CreatePostViewModel post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(postServices.CreatePost(post, userServices.GetUser(HttpContext.User.Identity.Name).UserId));
        }
    }
}
