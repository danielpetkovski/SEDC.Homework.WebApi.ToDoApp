using Microsoft.AspNetCore.Mvc;
using SEDC.Homework.WebApi.ToDoApp.Models;
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
    public class ToDoController : ControllerBase
    {
        private readonly IToDoService _toDoService;

        public ToDoController(IToDoService toDoService)
        {
            _toDoService = toDoService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ToDoDto>> Get([FromQuery]int userId)
        {
            try
            {
                return Ok(_toDoService.GetUserToDos(userId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoDto> Get(int id, [FromQuery]int userId)
        {
            try
            {
                return Ok(_toDoService.GetToDo(id, userId));
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id, [FromQuery] int userId)
        {
            try
            {
                _toDoService.DeleteToDo(id, userId);
                Debug.WriteLine($"ToDo with {id} has been deleted");
                return Ok($"Successfully deleted ToDo with id: {id}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TODO: {id}{ex.Message}");
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Post([FromBody]ToDoDto request)
        {
            try
            {
                _toDoService.AddToDo(request);
                Debug.WriteLine($"Added todo: {DateTime.Now} {request.Text}");
                return Ok($"Succesfully added todo: {request.Text}");
            }
            catch (Exception ex)
            {

                Debug.WriteLine($"TODO: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


    }
}
