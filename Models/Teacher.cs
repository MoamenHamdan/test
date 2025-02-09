using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Teachers")]
    public class Teacher
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int teacherId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string teacherName { get; set; }

        [Range(21, 62)]
        public int teacherAge { get; set; }
    }
}
