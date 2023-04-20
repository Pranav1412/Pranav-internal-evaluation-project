using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.Domain
{
    public class CourseDetails
    {
        [Key]
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public int Fees { get; set; }
    }
}
