using School.Context;
using School.Models;

namespace School.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        private readonly MyContext _context;

        public SubjectRepository(MyContext context)
        {
            _context = context;
        }

        public void create(Subject subject)
        {
            _context.Subjects.Add(subject);
            _context.SaveChanges();
        }

        public void delete(int id)
        {

            Subject subject = (from subObj in _context.Subjects
                               where subObj.subjectId == id
                               select subObj).FirstOrDefault();

           
            
                _context.Subjects.Remove(subject);
                _context.SaveChanges();
            

        }

        public List<Subject> getAllSubject()
        {
            return _context.Subjects.ToList();
        }
    }
}
