using HotelBookingAPI.Models;
using System.Xml.Linq;

namespace HotelBookingAPI.Repositorys
{
    public class InMemoryBookingRepository : IBookingRepository
    {
        private readonly List<Booking> _bookings = new();
        private int _nextId = 1;

        public Booking Add(Booking booking)
        {
            booking.Id = _nextId++;

            _bookings.Add(booking);

            return booking;
        }

        public IEnumerable<Booking> GetAll() => _bookings;

        public IEnumerable<Booking> GetBookingsFor(int roomId)
        {
            return _bookings.Where(b => b.RoomId == roomId);
        }
    }
}
