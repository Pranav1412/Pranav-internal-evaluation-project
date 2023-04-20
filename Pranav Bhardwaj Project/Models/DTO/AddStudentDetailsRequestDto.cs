using StudentsComputerCentre.Models.Domain;
using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class AddStudentDetailsRequestDto
    {
        [Key]
        public int iRoll { get; set; }
        public int CourseId { get; set; }

        public int FeesPaid { get; set; }

        public DateTime DateJoined { get; set; }

        //Navigation Properties

        public Students Students { get; set; }
        public CourseDetails CourseDetails { get; set; }
    }
}
