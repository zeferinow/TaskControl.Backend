using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Extensions;
using TaskControl.Backend.Models;
using TaskControl.Backend.Services;

namespace TaskControl.Backend.Controllers
{
    [Route("api/task")]
    [ApiController]
    [LazyInjection]
    public class TaskController : Controller
    {
        public TaskAppService TaskAppService { get; set; }
        public ProceedingAppService ProceedingAppService { get; set; }

        public TaskController(TaskAppService taskAppService,
                              ProceedingAppService proceedingAppService)
        {
            TaskAppService = taskAppService;
            ProceedingAppService = proceedingAppService;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TaskResume),HttpResponseCode.Ok)]
        public IActionResult AddTask([FromBody] AddTask addTask) 
        {
            var taskEntity = TaskAppService.Add(addTask);
            var taskResume = TaskAppService.ConvertTaskToTaskResume(taskEntity);

            return Created(nameof(AddTask), taskResume);
        }

        [HttpPost("proceeding")]
        [ProducesResponseType(HttpResponseCode.Created)]
        public IActionResult AddProceeding([FromBody] AddProceeding addProceeding)
        {
            var task = TaskAppService.GetCurrentUserTask(addProceeding.TaskId.ToObjectId());

            ProceedingAppService.AddProceeding(task, addProceeding);

            return Created(nameof(AddProceeding), null);
        }
    }
}
