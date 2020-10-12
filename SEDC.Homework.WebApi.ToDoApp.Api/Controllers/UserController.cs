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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpPost("authenticate")]
        public ActionResult<UserModel> Authenticate([FromBody]LoginModel request)
        {
            try
            {
                var response = _userService
                .Authenticate(request.Username, request.Password);

                Debug.WriteLine($"{response.Id} has been loged in");
                return Ok(response);
            }
            catch(UserException ex)
            {
                Debug.WriteLine($"USER: {ex.UserId}.{ex.Name} {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
                return BadRequest("Something went wrong");
            } 
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterModel request)
        {
            try
            {
                _userService.Register(request);
                Debug.WriteLine($"User registered with {request.Username}");
                return Ok("Successfully registered user");
            }
            catch(UserException ex)
            {
                Debug.WriteLine($"USER: {ex.UserId}.{ex.Name}: {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Unknown error: {ex.Message}");
                return BadRequest(ex.Message);
            }
        }


    }
}
