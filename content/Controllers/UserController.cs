using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModels.User;
using Services.Interfaces;

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

        [HttpGet]
        [Authorize]
        [Route("/user/getall")]
        public IActionResult GetAllUsers()
        {
            return Ok(userServices.GetFullUsers());
        }

        [HttpPost]
        [Route("/user/create")]
        public IActionResult Create([FromBody]CreateUserViewModel newUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = userServices.CreateUser(newUser);
            if (user == null)
            {
                return BadRequest("This login already exists");
            }

            return Ok(user);    
        }

        [HttpPost]
        [Route("/user/login")]
        public async Task<IActionResult> LogInAsync([FromBody]LogInUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var validUser = userServices.CheckUser(user);
            if (validUser == null)
            {
                return BadRequest("Login/password is invalid or account is not confirmed");
            }

            await AuthenticateAsync(user.Login);

            return Ok(validUser);
        }

        [Authorize]
        [Route("/user/logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return Ok();
        }

        private async Task AuthenticateAsync(string login)
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
