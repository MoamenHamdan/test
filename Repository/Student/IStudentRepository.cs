using School.Models;
using School.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School.Repository
{
    public interface IStudentRepository
    { 
        public List<Student> GetStudents();
        public void create(Student student);
        public void delete(int id);

        public void register(int studentID, int subjectId);



    }
}
