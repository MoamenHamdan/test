using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Students")]
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int studentId { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string studentName { get; set; }

        [Required]
        [Range(5, 20)]
        public int studentAge { get; set; }

        public bool isActive { get; set; }

        public string PhotoName { get; set; }

       
    }
}
