using HotelBookingAPI.Repositorys;

namespace HotelBookingAPI.Controllers.Room
{
    public class RoomService : IRoomService
    {
        public RoomService(IRoomRepository roomRepository, IBookingRepository bookingRepository)
        {
            _roomRepository = roomRepository;
            _bookingRepository = bookingRepository;
        }

        private readonly IRoomRepository _roomRepository;
        private readonly IBookingRepository _bookingRepository;

        public Models.Room AddRoom(string name)
        {
            return _roomRepository.Add(name);
        }

        public IEnumerable<Models.Room> GetAllRooms()
        {
            return _roomRepository.GetAll();
        }

        public Models.Room? GetById(int roomId)
        {
            var room = _roomRepository.GetById(roomId);
            if (room == null)
                throw new Exception("Room not found.");

            return room;
        }

        public IEnumerable<Models.Room> GetAvailableRooms(DateTime fromDate, DateTime toDate)
        {
            var allBookings = _bookingRepository.GetAll();

            var nonOverlappingBookings = allBookings
                .Where(b => !HasDateOverlap(b.FromDate, b.ToDate, fromDate, toDate))
                .ToList();

            var availableRooms = new List<Models.Room>();

            foreach (var booking in nonOverlappingBookings)
            {
                var room = _roomRepository.GetById(booking.RoomId);
                if (room != null)
                    availableRooms.Add(room);
            }

            return availableRooms;
        }

        public Models.Booking BookRoom(int roomId, string guestName, DateTime fromDate, DateTime toDate)
        {
            var room = _roomRepository.GetById(roomId);
            if (room == null)
                throw new Exception("Room not found.");

            if (fromDate >= toDate)
                throw new Exception("Invalid date range: fromDate must be earlier than toDate.");

            var allBookings = _bookingRepository.GetAll();
            var overlapping = allBookings.Any(b =>
                b.RoomId == roomId &&
                fromDate < b.ToDate &&
                toDate > b.FromDate
            );

            if (overlapping)
                throw new Exception("BookingOverlapException");

            var booking = new Models.Booking
            {
                RoomId = roomId,
                GuestName = guestName,
                FromDate = fromDate,
                ToDate = toDate
            };

            _bookingRepository.Add(booking);
            return booking;
        }

        private bool HasDateOverlap(DateTime bookingFrom, DateTime bookingTo, DateTime requestedFrom, DateTime requestedTo)
        {
            return bookingFrom < requestedTo && bookingTo > requestedFrom;
        }

        public IEnumerable<Models.Booking> GetBookings(int roomId)
        {
            return _bookingRepository.GetBookingsFor(roomId);
        }
    }
}
