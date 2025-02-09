using School.Context;
using School.Models;

namespace School.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly MyContext _context;

        public RoomRepository(MyContext context)
        {
            _context = context;
        }

        public void Create(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                _context.SaveChanges();
            }
        }

        public List<Room> GetAllRooms()
        {
            return _context.Rooms.ToList();
        }
    }
}
