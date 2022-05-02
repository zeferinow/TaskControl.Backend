using Ellevo.Api.Controllers;
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
        public Lazy<LoginAppService> LoginAppService { get; set; }

        /// <summary>
        ///     User login/authentication
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(JwtLogin), HttpResponseCode.Ok)]
        [ProducesResponseType(HttpResponseCode.PermissionDenied)]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] Login login)
        {
            var jwtToken = await LoginAppService.Value.Login(login);

            if(jwtToken != null)
            {
                return Ok(jwtToken);
            }

            throw new UnauthorizedAccessException("Username or password invalid");
        }
    }
}
