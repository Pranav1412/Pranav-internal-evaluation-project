using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class AddCourseDetailsRequestDto
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Fees { get; set; }
    }
}
