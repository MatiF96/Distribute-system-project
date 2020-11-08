using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using CinemaSystem.Utils;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IUsersService _usersService;

        public AdminController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        // GET: api/<AdminController>
        [HttpGet]
        [ProducesResponseType(typeof(IList<UserDto>), 200)]
        public async Task<ActionResult<IList<UserDto>>> GetAllAsync()
        {
            var results = await _usersService.GetAll();
            return Ok(results);
        }

        [HttpPost("user")]
        public async Task<ActionResult<UserDto>> EditUser([FromBody] EditUserDto editUser)
        {
            if (!UserRoles.isUserRole(editUser.Role))
            {
                return BadRequest(new ErrorMessage("Wrong user role"));
            }
            var result = await _usersService.EditUserRole(editUser.UserId, editUser.Role);
            return result != null ? Ok(result) : (ActionResult)BadRequest("User not found");
        }

        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> DeleteUser(int userId)
        {
            var result = await _usersService.DeleteUser(userId);
            return Ok(new { success = result });
        }
    }
}
