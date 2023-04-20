using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class AddStudentRequestDto
    {
        [Key]
        public int iRoll { get; set; }
        public string Name { get; set; }
    }
}
