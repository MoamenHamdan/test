using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;

namespace School.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;

        public StudentController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }



        //return List of Student from database
        [HttpGet]
        public ActionResult Index()
        {
            List<Student> students = _studentRepository.GetStudents();
            return View(students);
        }




        //Render The creation view 
        [HttpGet]
        public ViewResult Create()
        {
            return View();
        }




        //Create a new Student
        [HttpPost]
        public ActionResult Create(Student stuednt)
        {
            _studentRepository.create(stuednt);
            List<Student> students = _studentRepository.GetStudents();
            return View("Index", students);
        }

        //delete result 
        public ViewResult Delete(int id)
        {
            _studentRepository.delete(id);
            List<Student> students = _studentRepository.GetStudents();
            return View("Index", students);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Register(int studentId, int subjectId)
        {
            _studentRepository.register(studentId, subjectId);
            return View();

        }


    }
}
