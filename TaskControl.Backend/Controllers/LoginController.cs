using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Models;
using TaskControl.Backend.Services;

namespace TaskControl.Backend.Controllers
{
    [Route("api/login")]
    [ApiController]
    [LazyInjection]
    public class LoginController : Controller
    {
        public LoginAppService LoginAppService { get; set; }

        public LoginController(LoginAppService loginAppService)
        {
            LoginAppService = loginAppService;
        }
        /// <summary>
        ///     User login/authentication
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(JwtLogin), HttpResponseCode.Ok)]
        [ProducesResponseType(HttpResponseCode.PermissionDenied)]
        [AllowAnonymous]
        public IActionResult Login([FromBody] Login login)
        {
            var jwtToken = LoginAppService.Login(login);

            if(jwtToken != null)
            {
                return Ok(jwtToken);
            }

            return NotFound("User not found");
        }
    }
}
