using Microsoft.AspNetCore.Mvc;
using SEDC.Homework.WebApi.ToDoApp.Models;
using SEDC.Homework.WebApi.ToDoApp.Services.Exceptions;
using SEDC.Homework.WebApi.ToDoApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Homework.WebApi.ToDoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly ISubTaskService _subTaskService;

        public SubTaskController(ISubTaskService subTaskService)
        {
            this._subTaskService = subTaskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<SubTaskDto>> Get([FromQuery]int userId)
        {
            try
            {
                return Ok(_subTaskService.GetUserSubTasks(userId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<SubTaskDto> Get(int id, [FromQuery]int todoId, [FromQuery]int userId)
        {
            try
            {
                return Ok(_subTaskService.GetSubTask(userId, todoId, id));
                
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromQuery] int todoId, [FromQuery] int userId)
        {
            try
            {
                _subTaskService.DeleteSubTask(userId, todoId, id);
                Debug.WriteLine($"Successfully deleted Subtask {id}");
                return Ok("Successfully deleted Subtask");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SUBTASK: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]SubTaskDto request)
        {
            try
            {
                _subTaskService.AddSubTask(request);
                Debug.WriteLine($"Successfully added subtask: {request.Text}");
                return Ok($"Successfully added subtask: {request.Text}");
            }
            catch(SubTaskException ex)
            {
                Debug.WriteLine($"SUBTASK: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SUBTASK: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }

    }
}
