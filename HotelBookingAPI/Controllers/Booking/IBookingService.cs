namespace HotelBookingAPI.Controllers.Booking
{
    public interface IBookingService
    {
        Models.Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate);
        IEnumerable<Models.Booking> GetBookings(int roomId);
    }
}
