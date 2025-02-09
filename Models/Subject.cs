using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Models
{
    [Table("Subjects")]
    public class Subject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int subjectId { get; set; }



        [Required]
        [MaxLength(100)]
        public string subjectName { get; set; }


        [ForeignKey("Teacher")]
        public int teacherId { get; set; }
        public Teacher Teacher { get; set; }


  

        [Range(0,25)]
        public int subjectCapacity { get; set; }



    }
}
