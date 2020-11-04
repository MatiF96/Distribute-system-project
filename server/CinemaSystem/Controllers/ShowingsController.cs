using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using CinemaSystem.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowingsController : ControllerBase
    {
        private readonly IShowingsService _showingsService;

        public ShowingsController(IShowingsService showingsService)
        {
            _showingsService = showingsService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<ShowingDto>), 200)]
        public async Task<ActionResult<IList<ShowingDto>>> GetAll()
        {
            var result = await _showingsService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ShowingDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ShowingDto>> AddAsync([FromBody] AddShowingDto showing)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorMessage("Provide correct values"));
            var result = await _showingsService.AddShowing(showing);
            if (result == null) return NotFound(new ErrorMessage("Hall or Movie not found"));
            return Ok(result);
        }
    }
}
