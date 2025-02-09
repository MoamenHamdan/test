using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;

namespace School.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Room> rooms = _roomRepository.GetAllRooms();
            return View(rooms);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Room room)
        {
            _roomRepository.Create(room);
            List<Room> rooms = _roomRepository.GetAllRooms();
            return RedirectToAction("Index",rooms);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _roomRepository.Delete(id);
            List<Room> rooms = _roomRepository.GetAllRooms();
            return RedirectToAction("Index", rooms);
        }
    }
}
