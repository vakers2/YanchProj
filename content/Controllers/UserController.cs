using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels;
using Services.Interfaces;
using Services.Services;

namespace Vue2Spa.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices userServices;

        public UserController(IUserServices userServices)
        {
            this.userServices = userServices;
        }

        [HttpPost]
        [Route("/user/create")]
        public IActionResult Create([FromBody]CreateUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                return userServices.CreateUser(user) ? (IActionResult) Ok() : BadRequest("This login already exists");
            }

            return BadRequest(ModelState);
        }

        [HttpPost]
        [Route("/user/login")]
        public async Task<IActionResult> LogIn([FromBody]LogInUserViewModel user)
        {
            if (ModelState.IsValid)
            {
                var validUser = userServices.CheckUser(user);
                if (validUser != null)
                {
                    await Authenticate(user.Login);

                    return Ok(validUser);
                }

                return BadRequest("Login/password is invalid or account is not confirmed");
            }

            return BadRequest(ModelState);
        }

        [Authorize]
        [Route("/user/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

        private async Task Authenticate(string login)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, login)
            };

            var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
