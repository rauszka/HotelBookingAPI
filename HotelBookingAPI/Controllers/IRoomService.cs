using HotelBookingAPI.Models;

namespace HotelBookingAPI.Controllers
{
    public interface IRoomService
    {
        Room? AddRoom(string name);
        Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate);
        IEnumerable<Room> GetAvailableRooms(DateTime fromDate, DateTime toDate);
        IEnumerable<Booking> GetBookings(int roomId);
    }
}
