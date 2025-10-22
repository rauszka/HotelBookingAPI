using HotelBookingAPI.Models;

namespace HotelBookingAPI.Repositorys
{
    public class InMemoryRoomRepository : IRoomRepository
    {
        private readonly List<Room> _rooms = new();
        private int _nextId = 1;
        
        public IEnumerable<Room> GetAll() => _rooms;

        public Room Add(string name)
        {
            if (_rooms.Any(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase)))
                return null;

            var room = new Room
            {
                Id = _nextId++,
                Name = name
            };

            _rooms.Add(room);
            return room;
        }

        public Room? GetById(int id)
        {
            return _rooms.FirstOrDefault(r => r.Id == id);
        }

    }

}
