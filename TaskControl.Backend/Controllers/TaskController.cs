using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskControl.Backend.Controllers
{
    [Route("api/task")]
    [ApiController]
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
