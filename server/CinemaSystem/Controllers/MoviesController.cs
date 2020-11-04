using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using CinemaSystem.Utils;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;

        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IList<MovieDto>), 200)]
        public async Task<ActionResult<IList<MovieDto>>> GetAllAsync()
        {
            var results = await _moviesService.GetAll();
            return Ok(results);
        }

        [HttpGet("{movieId}")]
        [ProducesResponseType(typeof(MovieDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<MovieDto>> GetById(int movieId)
        {
            var result = await _moviesService.GetById(movieId);
            return result == null ? NotFound(new ErrorMessage("Movie not found")) : (ActionResult<MovieDto>)Ok(result);
        }

        [HttpGet("{movieId}/showings")]
        [ProducesResponseType(typeof(IList<ShowingDto>), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<IList<ShowingDto>>> GetShowings(int movieId)
        {
            var result = await _moviesService.GetShowings(movieId);
            return result == null ? NotFound(new ErrorMessage("Movie not found")) : (ActionResult)Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(MovieDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        public async Task<ActionResult<MovieDto>> CreateMovie([FromBody] AddMovieDto movie)
        {
            if (string.IsNullOrEmpty(movie.Title)) return BadRequest(new ErrorMessage("Title cannot be empty"));
            if (movie.Duration <= 0) return BadRequest(new ErrorMessage("Duration must be longer than 0 minutes"));

            var newMovie = await _moviesService.Add(movie);
            return Ok(newMovie);
        }

        [HttpPost("{movieId}")]
        [ProducesResponseType(typeof(MovieDto), 200)]
        [ProducesResponseType(typeof(ErrorMessage), 400)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult<MovieDto>> EditMovie(int movieId, [FromBody] EditMovieDto movie)
        {   // validate movie
            if (string.IsNullOrEmpty(movie.Title)) return BadRequest(new ErrorMessage("Title cannot be empty"));
            if (movie.Duration <= 0) return BadRequest(new ErrorMessage("Duration must be longer than 0 minutes"));
            var result = await _moviesService.Edit(movieId, movie);
            return result == null ? NotFound(new ErrorMessage("Movie not found")) : (ActionResult)Ok(result);
        }

        [HttpDelete("{movieId}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(typeof(ErrorMessage), 404)]
        public async Task<ActionResult> DeleteMovie(int movieId)
        {
            var result = await _moviesService.Delete(movieId);
            return result == null ? NotFound(new ErrorMessage("Movie not found")) : (ActionResult)Ok();
        }
    }
}
