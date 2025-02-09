using Microsoft.AspNetCore.Mvc;
using School.Models;
using School.Repository;

namespace School.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly ITeacherRepository _teacherRepository;

        public SubjectController(ISubjectRepository subjectRepository, ITeacherRepository teacherRepository )
        {
            _subjectRepository = subjectRepository;
            _teacherRepository = teacherRepository;
        }
        [HttpGet]
        public ActionResult Index() {
            List<Subject> subjects = _subjectRepository.getAllSubject();
            return View( subjects);
        }
        [HttpGet]
        public ViewResult Create()
        {
            List<Subject> subjects = _subjectRepository.getAllSubject();
            List<Teacher> teachers = _teacherRepository.GetAllTeachers();
            return View(teachers);
        }
        [HttpPost]
        public ActionResult Create(Subject subject)
        { 
            _subjectRepository.create(subject);
            List<Subject> subjects = _subjectRepository.getAllSubject();
            return RedirectToAction("Index",subjects);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            _subjectRepository.delete(id);
            List<Subject> subjects = _subjectRepository.getAllSubject();
            return RedirectToAction("Index", subjects);
        }
    

    }
}
