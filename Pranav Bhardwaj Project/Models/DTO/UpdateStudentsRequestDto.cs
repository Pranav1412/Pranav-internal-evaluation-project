using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.DTO
{
    public class UpdateStudentsRequestDto
    {
        [Key]
        public int iRoll { get; set; }
        public string Name { get; set; }
    }
}
