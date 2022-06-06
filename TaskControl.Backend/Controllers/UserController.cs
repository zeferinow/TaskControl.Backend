using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Models;
using TaskControl.Backend.Services;

namespace TaskControl.Backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : Controller
    {
        public UserAppService UserAppService { get; set; }

        public UserController(UserAppService userAppService)
        {
            UserAppService = userAppService;
        }

        [HttpPost]
        [ProducesResponseType(HttpResponseCode.Created)]
        public IActionResult AddUser(AddUser addUser)
        {
            UserAppService.Add(addUser);

            return Created(nameof(AddUser), null);
        }

        [HttpGet("is-user-admin")]
        [ProducesResponseType(typeof(bool), HttpResponseCode.Ok)]
        public IActionResult IsCurrentUserAdmin()
        {
            return Ok(UserAppService.IsCurrentUserAdmin());
        }

        [HttpGet("list")]
        [ProducesResponseType(typeof(UserListData), HttpResponseCode.Ok)]
        public IActionResult GetUserListData()
        {
            return Ok(UserAppService.GetData());
        }

        [HttpPut]
        [ProducesResponseType(HttpResponseCode.NoContent)]
        public IActionResult UpdateUser([FromBody] UpdateUser updateUser)
        {
            UserAppService.Update(updateUser);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), HttpResponseCode.NoContent)]
        public IActionResult DeleteUser(string id)
        {
            UserAppService.Delete(id);
            return NoContent();
        }
    }
}
