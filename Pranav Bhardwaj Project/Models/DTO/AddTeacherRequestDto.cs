using StudentsComputerCentre.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class AddTeacherRequestDto
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }

        public CourseDetails CourseDetails { get; set; }
    }
}
