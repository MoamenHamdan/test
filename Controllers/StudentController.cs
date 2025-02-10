using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Models.NewFolder2;
using School.Repository;

namespace School.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentRepository _studentRepository;
        private readonly ISubjectRepository _subjectRepository;
        private readonly IWebHostEnvironment _hostEnvironment;

        public StudentController(IStudentRepository studentRepository, ISubjectRepository subjectRepository, IWebHostEnvironment hostEnvironment)
        {
            _studentRepository = studentRepository;
            _subjectRepository = subjectRepository;
            _hostEnvironment = hostEnvironment;
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
        public ActionResult Create(Student stuednt,IFormFile StudentPhoto)
        {
            var wwwrootPath = _hostEnvironment.WebRootPath + "/StudentPic/";
            Guid guid = Guid.NewGuid();

            string fullPath = System.IO.Path.Combine(wwwrootPath, guid + StudentPhoto.FileName );

            using (var fileStream = new FileStream(fullPath, FileMode.Create))
            {
                StudentPhoto.CopyTo(fileStream);
            };


            stuednt.PhotoName = guid + StudentPhoto.FileName;

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
            StudentCourseVM studentCourseVM = new StudentCourseVM();
            studentCourseVM.c = _subjectRepository.getAllSubject();
            studentCourseVM.s = _studentRepository.GetStudents();
            return View(studentCourseVM);
             
        }


        [HttpPost]
        public ActionResult Register(int studentId, int subjectId)
        {
            _studentRepository.register(studentId, subjectId);
            return RedirectToAction("Register");

        }


    }
}
