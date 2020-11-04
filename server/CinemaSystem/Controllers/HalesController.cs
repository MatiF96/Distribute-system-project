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
    public class HalesController : ControllerBase
    {
        private readonly IHalesService _halesService;

        public HalesController(IHalesService halesService)
        {
            _halesService = halesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<HallDto>), 200)]
        public async Task<ActionResult<IList<HallDto>>> GetAllAsync()
        {
            var results = await _halesService.GetHales();
            return Ok(results);
        }

        [HttpGet("{hallId}")]
        [ProducesResponseType(typeof(HallDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<HallDto>> GetById(int hallId)
        {
            var result = await _halesService.GetById(hallId);
            if (result == null) return NotFound(new ErrorMessage("Hall not found"));
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(HallDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<HallDto>> Add([FromBody] AddEditHallDto hall)
        {
            if (string.IsNullOrEmpty(hall.Name)) return BadRequest(new ErrorMessage("Name must not be empty"));
            var result = await _halesService.AddHall(hall);
            return Ok(result);
        }

        [HttpPost("{hallId}")]
        [ProducesResponseType(typeof(HallDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<HallDto>> Edit(int hallId, [FromBody] AddEditHallDto hall)
        {
            if (string.IsNullOrEmpty(hall.Name)) return BadRequest(new ErrorMessage("Name must not be empty"));
            var result = await _halesService.EditHall(hallId, hall);
            if (result == null) return NotFound(new ErrorMessage("Hall not found"));
            return Ok(result);
        }

        [HttpDelete("{hallId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<HallDto>> Delete(int hallId)
        {
            var result = await _halesService.DeleteHall(hallId);
            if (result == null) return NotFound(new ErrorMessage("Hall not found"));
            return Ok();
        }
    }
}
