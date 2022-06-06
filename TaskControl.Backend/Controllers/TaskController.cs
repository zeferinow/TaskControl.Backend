using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskControl.Backend.Attributes;
using TaskControl.Backend.Entities.MongoDb;
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
        [ProducesResponseType(typeof(TaskResume), HttpResponseCode.Ok)]
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

        [HttpGet("list")]
        [ProducesResponseType(typeof(TaskListData), HttpResponseCode.Ok)]
        public IActionResult GetTaskListData()
        {
            return Ok(TaskAppService.GetData());
        }

        [HttpGet("{taskId}")]
        [ProducesResponseType(typeof(TaskView), HttpResponseCode.Ok)]
        public IActionResult GetTask([FromRoute] string taskId)
        {
            return Ok(TaskAppService.GetTask(taskId));
        }

        [HttpGet("proceeding-list/{taskId}")]
        [ProducesResponseType(typeof(TaskView), HttpResponseCode.Ok)]
        public IActionResult GetProceedingListData([FromRoute] string taskId)
        {
            return Ok(ProceedingAppService.GetProceedingData(taskId));
        }

        [HttpGet("new-sequence-number")]
        [ProducesResponseType(typeof(int), HttpResponseCode.Ok)]
        public IActionResult GetNewSequenceNumber()
        {
            return Ok(TaskAppService.GetNewSequenceNumber());
        }

        [HttpPut("{taskId}")]
        [ProducesResponseType(HttpResponseCode.NoContent)]
        public IActionResult UpdateTicket([FromRoute] string ticketId, [FromBody] UpdateTask updateTicket)
        {
            TaskAppService.Update(new ObjectId(ticketId), updateTicket);
            return NoContent();
        }
    }
}
