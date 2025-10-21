using HotelBookingAPI.Models;

namespace HotelBookingAPI.Controllers
{
    public class RoomService : IRoomService
    {
        private static readonly List<Room> _rooms = new();
        private static readonly List<Booking> _bookings = new();
        private static int _roomIdCounter = 1;
        private static int _bookingIdCounter = 1;

        public Room AddRoom(string name)
        {
            if (_rooms.Any(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                return null;

            var room = new Room
            {
                Id = _roomIdCounter++,
                Name = name
            };

            _rooms.Add(room);
            return room;
        }

        public Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public List<Room> GetAllRooms()
        {
            return _rooms;
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Booking> GetBookings(int roomId)
        {
            throw new NotImplementedException();
        }
    }
}
