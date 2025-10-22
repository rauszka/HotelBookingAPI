namespace HotelBookingAPI.Models
{
    public class Booking
    {
        public Guid Id { get; set; }
        public Guid RoomId { get; set; }
        public string GuestName { get; set; } = null!;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }
}
