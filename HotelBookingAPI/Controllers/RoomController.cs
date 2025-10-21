using Microsoft.AspNetCore.Mvc;

namespace HotelBookingAPI.Controllers
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
        public IActionResult AddRoom([FromBody] string request)
        {
            if (string.IsNullOrWhiteSpace(request))
                return BadRequest(new { error = "Room name is required." });

            var room = _roomService.AddRoom(request);
            if (room == null)
                return Conflict(new { error = "Room with this name already exists." });

            return Created();
        }
    }
}
