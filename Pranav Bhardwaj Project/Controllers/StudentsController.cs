using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsComputerCentre.Data;
using StudentsComputerCentre.Models.Domain;
using StudentsComputerCentre.Models.DTO;

namespace StudentsComputerCentre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly StudentTeacherDbContext dbContext;

        public StudentsController(StudentTeacherDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET All Student
        [HttpGet]
        public IActionResult GetAll()
        {
            var studentsDomain = dbContext.studentes.ToList();
            //Map Domain Models to DTO
            var studentsDto = new List<StudentsDto>();
            foreach (var studentDomain in studentsDomain)
            {
                studentsDto.Add(new StudentsDto()
                {
                    iRoll = studentDomain.iRoll,
                    Name = studentDomain.Name
                });    
            }
            return Ok(studentsDomain);
        }

        //GET Single Student by iRoll
        [HttpGet]
        [Route("{iRoll:int}")]
        public IActionResult GetbyiRoll([FromRoute] int iRoll) { 
        
            var studentDomain = dbContext.studentes.FirstOrDefault(x => x.iRoll == iRoll);
            if(studentDomain == null)
            {
                return NotFound();
            }

            //Convert Student Domain Model to Studnet Dto
            var studentDto = new StudentsDto
            {
                iRoll = studentDomain.iRoll,
                Name = studentDomain.Name
            };

            return Ok(studentDto);
        }


        //POST to Create new Student
        [HttpPost]
        public IActionResult Create([FromBody] AddStudentRequestDto addStudentRequestDto)
        {
            //Map DTO to Domain Model
            var studentDomainModel = new Students
            {
                iRoll = addStudentRequestDto.iRoll,
                Name = addStudentRequestDto.Name
            };

            //Use DOmain Model to Create Student
            dbContext.studentes.Add(studentDomainModel);
            dbContext.SaveChanges();

            //Map Domain Model Back to DTO
            var studentDto = new StudentsDto
            {
                iRoll = studentDomainModel.iRoll,
                Name = studentDomainModel.Name
            };

            return CreatedAtAction(nameof(GetbyiRoll), new { iroll = studentDto.iRoll }, studentDto);
        }

        //PUT to Update a Student

        [HttpPut]
        [Route("{iRoll:int}")]

        public IActionResult Update([FromRoute] int iRoll, [FromBody] UpdateStudentsRequestDto updateStudentsRequestDto)
        {
            //Check if Student iRoll Exists
            var studentDomainModel = dbContext.studentes.FirstOrDefault(x => x.iRoll == iRoll);

            if(studentDomainModel == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model

            studentDomainModel.iRoll = updateStudentsRequestDto.iRoll;
            studentDomainModel.Name = updateStudentsRequestDto.Name;

            dbContext.SaveChanges();

            //Convert Domain Model to DTO

            var studentDto = new StudentsDto
            {
                iRoll = studentDomainModel.iRoll,
                Name = studentDomainModel.Name
            };

            return Ok(studentDto);

        }

        //DELETE a student by iRoll

        [HttpDelete]
        [Route("{iRoll:int}")]

        public IActionResult Delete([FromRoute] int iRoll)
        {
            //Check if iRoll exist or not
            var studentDomainModel = dbContext.studentes.FirstOrDefault(x => x.iRoll == iRoll);

            if(studentDomainModel == null)
            {
                return NotFound();
            }
            //Delete Student
            dbContext.studentes.Remove(studentDomainModel);
            dbContext.SaveChanges();
            //if we want to see the deleted student details
            //Map Domain Model to DTO
            var studentDto = new StudentsDto
            {
                iRoll = studentDomainModel.iRoll,
                Name = studentDomainModel.Name
            };

            return Ok(studentDto);


        }

    }
}
