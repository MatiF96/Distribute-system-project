using System.Collections.Generic;
using System.Threading.Tasks;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using CinemaSystem.Utils;
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

        [HttpGet("{showingId}")]
        [ProducesResponseType(typeof(ShowingDto), 200)]
        public async Task<ActionResult<ShowingDto>> Get(int showingId)
        {
            var result = await _showingsService.GetById(showingId);
            return result == null ? NotFound(new ErrorMessage("Showing not found")) : (ActionResult)Ok(result);
        }

        [HttpDelete("{showingId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult> Delete(int showingId)
        {
            var result = await _showingsService.DeleteShowing(showingId);
            return result == null ? BadRequest(new ErrorMessage("Showing not found")) : (ActionResult)Ok();
        }


        [HttpPost]
        [ProducesResponseType(typeof(ShowingDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ShowingDto>> AddAsync([FromBody] AddShowingDto showing)
        {
            if (!ModelState.IsValid) return BadRequest(new ErrorMessage("Provide correct values"));
            var result = await _showingsService.AddShowing(showing);
            if (result == null) return NotFound(new ErrorMessage("Hall or Movie not found"));
            return Ok(result);
        }

        [HttpPost("{showingId}")]
        [ProducesResponseType(typeof(ShowingDto), 200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<ShowingDto>> Edit(int showingId, [FromBody] EditShowingDto showing)
        {
            if (await _showingsService.GetById(showingId) == null) return NotFound("Showing not found");
            var result = await _showingsService.EditShowing(showingId, showing);
            if (result == null) return NotFound(new ErrorMessage("Hall or Movie not found"));
            return Ok(result);
        }

        [HttpGet("{showingId}/seats")]
        [ProducesResponseType(typeof(IList<SeatDto>), 200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<IList<SeatDto>>> GetTakenSeats(int showingId)
        {
            var result = await _showingsService.GetTakenSeats(showingId);
            return result == null ? NotFound(new ErrorMessage("Showing not found")) : (ActionResult)Ok(result);
        }

    }
}
