using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositorys
{
    public interface IBookingRepository
    {
        Booking Add(Booking booking);
        IEnumerable<Booking> GetAll();
        IEnumerable<Booking> GetBookingsFor(Guid roomId);

    }

}
