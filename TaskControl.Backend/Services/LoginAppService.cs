using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Entities.MongoDb;
using TaskControl.Backend.Models;

namespace TaskControl.Backend.Services
{
    [LazyInjection]
    public class LoginAppService
    {
        public Lazy<UserAppService> UserAppService { get; set; }

        public IConfiguration _config;

        public LoginAppService(IConfiguration config)
        {
            _config = config;
        }

        public JwtLogin Login(Login login)
        {
            var userEntity = UserAppService.Value.GetByLogin(login.UserLogin).FirstOrDefault();

            if(userEntity != null)
            {
                var user = Authenticate(userEntity, login);

                if(user == null)
                {
                    return null;
                }

                var token = GenerateToken(user);

                return new JwtLogin
                {
                    AccessToken = token
                };
            };

            return null;
        }

        private User Authenticate(UserEntity user, Login login)
        {
            VerifyCredentials(login, user);

            return new User
            {
                Id = user.Id.ToString(),
                Name = user.Name,
                Login = user.Login,
                Password = user.Password
            };
        }

        private string GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.NameIdentifier, user.Login)
            };

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private void VerifyCredentials(Login login, UserEntity user)
        {
            if(user.Password != login.Password)
            {
                throw new UnauthorizedAccessException("Not authorized");
            }
        }
    }
}
