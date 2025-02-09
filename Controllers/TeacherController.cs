using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly ITeacherRepository _teacherRepository;

        public TeacherController(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        [HttpGet]
        public ActionResult Index()
        {
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }

        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Teacher teacher)
        {
            _teacherRepository.Create(teacher);
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index" , teachers);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            _teacherRepository.Delete(id);
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View("Index", teachers);
        }
    }
}
