using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using my_books.Data;
using my_books.Data.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // Inject IConfiguration object to can acsess appsettings File 
        private IConfiguration _config;
        public UsersService _usersService;
        public LoginController(IConfiguration config, UsersService usersService)
        {
            _config = config;
            _usersService = usersService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserLogin userLogin)
        {
            var user = Authenticate(userLogin);
            if (user != null)
            {
                var token = Generate(user);
                return Ok(token);
            }
            return NotFound("User Not Found");
        }

        private string Generate(UserInfo user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var cerdentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Email , user.EmailAddress),
                new Claim(ClaimTypes.GivenName , user.GivenName),
                new Claim(ClaimTypes.Surname , user.SurName),
                new Claim(ClaimTypes.Role , user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials : cerdentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private UserInfo Authenticate(UserLogin userLogin)
        {
            var userName = userLogin.UserName.ToLower();
            var pass = userLogin.Password;
            var currentUser = _usersService.GetUserByName(userName, pass);
            if (currentUser != null)
            {
                return currentUser;
            }
            return null;
        }
    }
}
