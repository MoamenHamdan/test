using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    public class StudentCourse
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentCourseId { get; set; }
        [ForeignKey("Student")]
        public int studentId { get; set; }
        public Student Student { get; set; }

        [ForeignKey("Subject")]
        public int subjectId { get; set; }
        public Subject Subject
        {
            get; set;






        }
    }
}
