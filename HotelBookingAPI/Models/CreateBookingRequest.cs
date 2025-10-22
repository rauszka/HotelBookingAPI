namespace HotelBookingAPI.Models
{
    public class CreateBookingRequest
    {
        public string GuestName { get; set; } = string.Empty;
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
    }

}
