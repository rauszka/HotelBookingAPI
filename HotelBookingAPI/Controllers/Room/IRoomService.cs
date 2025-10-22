namespace HotelBookingAPI.Controllers.Room
{
    public interface IRoomService
    {
        Models.Room AddRoom(string name);
        IEnumerable<Models.Room> GetAllRooms();
        IEnumerable<Models.Room> GetAvailableRooms(DateTime fromDate, DateTime toDate);
        Models.Booking BookRoom(Guid roomId, string guestName, DateTime fromDate, DateTime toDate);
        IEnumerable<Models.Booking> GetBookings(Guid roomId);
        Models.Room? GetById(Guid roomId);
    }
}
