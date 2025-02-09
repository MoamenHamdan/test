using School.Models;

namespace School.Repository
{
    public interface ISubjectRepository
    {

        public List<Subject> getAllSubject();
        public void create(Subject subject);
        public void delete(int id);

     

    }
}
