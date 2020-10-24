using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CinemaSystem.Services;
using CinemaSystem.Services.Models;
using CinemaSystem.Utils;
using Microsoft.AspNetCore.Mvc;


namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult> Login([FromBody] AuthDto credentials)
        {
            var result = await _authService.Login(credentials);
            return result == null ? BadRequest(new ErrorMessage("Invalid credentials")) : (ActionResult)Ok(result);
        }

        [HttpPost("register")]
        [ProducesResponseType(typeof(UserDto), 200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> Register(AuthDto credentials)
        {
            var result = await _authService.Register(credentials);
            return Ok(result);
        }

    }
}
