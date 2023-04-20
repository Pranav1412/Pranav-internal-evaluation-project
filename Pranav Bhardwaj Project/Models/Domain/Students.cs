using System.ComponentModel.DataAnnotations;

namespace StudentsComputerCentre.Models.Domain
{
    public class Students
    {
        [Key]
        public int iRoll { get; set; }
        public string Name { get; set; }
    }
}
