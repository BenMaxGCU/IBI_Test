using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTestIBI.Context;
using TechTestIBI.Models;

namespace TechTestIBI.Controllers
{
    [ApiController] // Declaring that this is a controller
    [Route("/[controller]")] // Giving the endpoint of /users
    public class UsersController : Controller
    {
        // Creating an instance of DbContext
        private readonly ApplicationDbContext _context;
        private IConfiguration _config;
        private GenerateJSONWebToken _generateToken;

        // Constructor
        public UsersController (ApplicationDbContext context, IConfiguration config, GenerateJSONWebToken generateToken)
        {
            _context = context;
            _config = config;
            _generateToken = generateToken;
        }

        // Post: /users
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]string UserName)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(UserName);

            // If the user name is found
            if (UserExists(UserName))
            {
                var tokenString = _generateToken.GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            else
            {
                return UnprocessableEntity();
            }

            return response;
        }

        private bool UserExists(string UserName)
        {
            return _context.Users.Any(e => e.Name == UserName);
        }

        private User AuthenticateUser(string UserName)
        {
            User user = null;

            if(UserName == _context.Users.Find(user.Name).Name)
            {
                user = new User { UserId = user.UserId, Name = user.Name };
            }
            return user;
        }
    }
}
