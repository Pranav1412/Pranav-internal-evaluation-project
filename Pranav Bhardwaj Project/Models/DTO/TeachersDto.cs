using StudentsComputerCentre.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class TeachersDto
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }

        public CourseDetails CourseDetails { get; set; }
    }
}
