using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class CourseDetailsDto
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Fees { get; set; }
    }
}
