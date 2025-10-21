using HotelBookingAPI.Models;

namespace HotelBookingAPI.Controllers
{
    public class RoomService : IRoomService
    {
        public Room? AddRoom(string name)
        {
            throw new NotImplementedException();
        }

        public Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
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
