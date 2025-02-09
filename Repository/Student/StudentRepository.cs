using School.Context;
using School.Models;

namespace School.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly MyContext _context;

        public StudentRepository(MyContext context)
        {
            _context = context;
        }

        public void create(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
        }

        public void delete(int id)
        {
            Student student = (from stdObj in _context.Students
                                 where stdObj.studentId == id
                                 select stdObj).FirstOrDefault();
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        public List<Student> GetStudents()
        {
            
            List<Student> students = (from stdObj in _context.Students
                                      select stdObj).ToList();
            return students;
        }

        public void register(int studentID, int subjectId)
        {
           
            _context.Registrations.Add(new StudentCourse {
                studentId = studentID,
                subjectId = subjectId
            });

        }
    }
}
