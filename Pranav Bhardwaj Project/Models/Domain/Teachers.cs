using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.Domain
{
    public class Teachers
    {
        [Key]
        public int TeacherId { get; set; }
        public string TeacherName { get; set; }

        public int CourseId { get; set; }

        public CourseDetails CourseDetails { get; set; }
    }
}
