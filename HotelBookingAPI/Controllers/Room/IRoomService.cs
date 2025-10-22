namespace HotelBookingAPI.Controllers.Room
{
    public interface IRoomService
    {
        Models.Room AddRoom(string name);
        IEnumerable<Models.Room> GetAllRooms();
        IEnumerable<Models.Room> GetAvailableRooms(DateTime fromDate, DateTime toDate);
        Models.Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate);
        IEnumerable<Models.Booking> GetBookings(int roomId);
        Models.Room? GetById(int roomId);
    }
}
