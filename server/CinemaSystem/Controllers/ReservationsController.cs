using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database.Models;
using CinemaSystem.Hubs;
using CinemaSystem.Repositories;
using CinemaSystem.Services;
using CinemaSystem.Services.DTO;
using CinemaSystem.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.VisualBasic.FileIO;

namespace CinemaSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IHubContext<ReservationHub> _hubContext;
        private readonly IShowingsService _showingsService;
        private readonly IReservationsService _reservationsService;
        public ReservationsController(IHubContext<ReservationHub> hubContext, IShowingsService showingsService, IReservationsService reservationsService)
        {
            _hubContext = hubContext;
            _showingsService = showingsService;
            _reservationsService = reservationsService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] AddReservationDto reservation)
        {
            var takenSeats = await _showingsService.GetTakenSeats(reservation.ShowingId);
            if(reservation.Seat <= 0) return BadRequest(new ErrorMessage($"Seat number must be greater than 0"));
            if (takenSeats.Select(s => s.Number).Contains(reservation.Seat))
            {
                return BadRequest(new ErrorMessage($"Seat {reservation.Seat} is already taken!"));
            }
            await _reservationsService.Add(reservation);
            var seats = await _showingsService.GetTakenSeats(reservation.ShowingId);
            await _hubContext.Clients.All.SendAsync("OnSeatsChanged", seats);
            return Ok();
        }

        [HttpPost("complete")]
        public async Task<ActionResult> Complete([FromBody] CompleteReservationDto completeReservation)
        {
            var reservationIds = await _showingsService.GetUserReservations(completeReservation.ShowingId, completeReservation.UserId);
            await _reservationsService.SetCompleted(reservationIds);
            var seats = await _showingsService.GetTakenSeats(completeReservation.ShowingId);
            await _hubContext.Clients.All.SendAsync("OnSeatsChanged", seats);
            return Ok();
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> Delete([FromBody] CompleteReservationDto completeReservation)
        {
            var reservationIds = await _showingsService.GetUserReservations(completeReservation.ShowingId, completeReservation.UserId);
            await _reservationsService.DeleteReservations(reservationIds);
            var seats = await _showingsService.GetTakenSeats(completeReservation.ShowingId);
            await _hubContext.Clients.All.SendAsync("OnSeatsChanged", seats);
            return Ok();
        }

    }

}
