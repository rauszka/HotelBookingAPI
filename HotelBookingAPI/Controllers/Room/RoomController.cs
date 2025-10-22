using HotelBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers.Room
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        /// <summary>
        /// Get all rooms
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult GetAllRooms()
        {
            var rooms = _roomService.GetAllRooms();

            if (rooms == null || !rooms.Any())
                return NotFound(new { error = "No rooms found." });

            return Ok(rooms);
        }

        /// <summary>
        /// Create a new room
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddRoom([FromBody] CreateRoomRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Name))
                return BadRequest(new { error = "Room name is required." });

            var room = _roomService.AddRoom(request.Name);
            if (room == null)
                return Conflict(new { error = "Room with this name already exists." });

            return Created();
        }

        /// <summary>
        /// Get available rooms for a given date range
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet("available")]
        public ActionResult<IEnumerable<Models.Room>> GetAvailableRooms([FromQuery] DateTime fromDate, [FromQuery] DateTime toDate)
        {
            if (fromDate >= toDate)
            {
                return BadRequest("fromDate must be earlier than toDate.");
            }

            var availableRooms = _roomService.GetAvailableRooms(fromDate, toDate);
            return Ok(availableRooms);
        }

        /// <summary>
        /// Book a room
        /// </summary>
        /// <param name="roomId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost("{roomId}/bookings")]
        public ActionResult<Models.Booking> BookRoom(int roomId, [FromBody] CreateBookingRequest request)
        {
            if (request.FromDate >= request.ToDate)
                return BadRequest("fromDate must be earlier than toDate.");

            try
            {
                var booking = _roomService.BookRoom(
                    roomId,
                    request.GuestName,
                    request.FromDate,
                    request.ToDate
                );

                return Created();
                
            }
            //catch (BookingOverlapException)
            //{
            //    return Conflict("The room is already booked for the specified dates.");
            //}
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }   
        }

        /// <summary>
        /// Get bookings for a specific room
        /// </summary>
        /// <param name="roomId"></param>
        /// <returns></returns>
        [HttpGet("{roomId}/bookings")]
        public ActionResult<IEnumerable<Models.Booking>> GetBookings(int roomId)
        {
            var room = _roomService.GetById(roomId);
            if (room == null)
                return NotFound("Room not found.");

            var bookings = _roomService.GetBookings(roomId);

            return Ok(bookings);
        }
    }
}
