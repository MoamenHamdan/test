using School.Models;

namespace School.Repository
{
    public interface ITeacherRepository
    {
        public List<Teacher> GetAllTeachers();
        public void Create(Teacher teacher);
        public void Delete(int id);
    }
}
