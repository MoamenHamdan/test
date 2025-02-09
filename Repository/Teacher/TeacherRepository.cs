using School.Context;
using School.Models;

namespace School.Repository
{
    public class TeacherRepository : ITeacherRepository
    {
        private readonly MyContext _context;

        public TeacherRepository(MyContext context)
        {
            _context = context;
        }

        public void Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var teacher = _context.Teachers.Find(id);
            if (teacher != null)
            {
                _context.Teachers.Remove(teacher);
                _context.SaveChanges();
            }
        }

        public List<Teacher> GetAllTeachers()
        {
            List<Teacher> teachers = _context.Teachers.ToList();
            return teachers;

        }
    }
}
