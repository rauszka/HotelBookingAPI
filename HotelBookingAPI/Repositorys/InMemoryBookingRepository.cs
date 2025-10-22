using HotelBookingAPI.Models;
using System.Xml.Linq;

namespace HotelBookingAPI.Repositorys
{
    public class InMemoryBookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new();
        public Booking Add(Booking booking)
        {
            _bookings.Add(booking);

            return booking;
        }

        public IEnumerable<Booking> GetAll() => _bookings;

        public IEnumerable<Booking> GetBookingsFor(Guid roomId)
        {
            return _bookings.Where(b => b.RoomId == roomId);
        }
    }
}
