using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositorys
{
    public interface IRoomRepository
    {
        IEnumerable<Room> GetAll();
        Room Add(string name);
        Room? GetById(int id);
    }

}
