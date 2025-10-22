using HotelBookingAPI.Repositorys;

namespace HotelBookingAPI.Controllers.Booking
{
    public class BookingService
    {
        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        public Models.Booking BookRoom(Guid roomId, string guestName, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }
    }

}
