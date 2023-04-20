using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsComputerCentre.Data;
using StudentsComputerCentre.Models.Domain;
using StudentsComputerCentre.Models.DTO;

namespace StudentsComputerCentre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsDetailsController : ControllerBase
    {
        private readonly StudentTeacherDbContext dbContext;

        public StudentsDetailsController(StudentTeacherDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET All StudentDetails
        [HttpGet]
        public IActionResult GetAll()
        {
            var studentsDomain = dbContext.studentDetails.ToList();
            //Map Domain Models to DTO
            var studentsDto = new List<StudentDetailsDto>();
            foreach (var studentDomain in studentsDomain)
            {
                studentsDto.Add(new StudentDetailsDto()
                {
                    iRoll = studentDomain.iRoll,
                    CourseId = studentDomain.CourseId,
                    FeesPaid = studentDomain.FeesPaid,
                    DateJoined = studentDomain.DateJoined
                });
            }
            return Ok(studentsDomain);
        }

        //GET Single StudentDetails by iRoll
        [HttpGet]
        [Route("{iRoll:int}")]
        public IActionResult GetbyiRoll([FromRoute] int iRoll)
        {

            var studentDomain = dbContext.studentDetails.FirstOrDefault(x => x.iRoll == iRoll);
            if (studentDomain == null)
            {
                return NotFound();
            }

            //Convert Student Domain Model to Studnet Dto
            var studentDto = new StudentDetailsDto
            {
                iRoll = studentDomain.iRoll,
                CourseId = studentDomain.CourseId,
                FeesPaid = studentDomain.FeesPaid,
                DateJoined = studentDomain.DateJoined
            };

            return Ok(studentDto);
        }


        //POST to Create new StudentDetails
        [HttpPost]
        public IActionResult Create([FromBody] AddStudentDetailsRequestDto addStudentDetailsRequestDto)
        {
            //Map DTO to Domain Model
            var studentDomainModel = new StudentDetails
            {
                iRoll = addStudentDetailsRequestDto.iRoll,
                CourseId = addStudentDetailsRequestDto.CourseId,
                FeesPaid = addStudentDetailsRequestDto.FeesPaid,
                DateJoined = addStudentDetailsRequestDto.DateJoined
            };

            //Use DOmain Model to Create Student
            dbContext.studentDetails.Add(studentDomainModel);
            dbContext.SaveChanges();

            //Map Domain Model Back to DTO
            var studentDto = new StudentDetailsDto
            {
                iRoll = studentDomainModel.iRoll,
                CourseId = studentDomainModel.CourseId,
                FeesPaid = studentDomainModel.FeesPaid,
                DateJoined = studentDomainModel.DateJoined
            };

            return CreatedAtAction(nameof(GetbyiRoll), new { iroll = studentDto.iRoll }, studentDto);
        }

        //PUT to Update a StudentDetails

        [HttpPut]
        [Route("{iRoll:int}")]

        public IActionResult Update([FromRoute] int iRoll, [FromBody] UpdateStudentDetailsRequestDto updateStudentDetailsRequestDto)
        {
            //Check if Student iRoll Exists
            var studentDomainModel = dbContext.studentDetails.FirstOrDefault(x => x.iRoll == iRoll);

            if (studentDomainModel == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model

            studentDomainModel.iRoll = updateStudentDetailsRequestDto.iRoll;
            studentDomainModel.CourseId = updateStudentDetailsRequestDto.CourseId;
            studentDomainModel.FeesPaid = updateStudentDetailsRequestDto.FeesPaid;
            studentDomainModel.DateJoined = updateStudentDetailsRequestDto.DateJoined;

            dbContext.SaveChanges();

            //Convert Domain Model to DTO

            var studentDto = new StudentDetailsDto
            {
                iRoll = studentDomainModel.iRoll,
                CourseId = studentDomainModel.CourseId,
                FeesPaid = studentDomainModel.FeesPaid,
                DateJoined = studentDomainModel.DateJoined
            };

            return Ok(studentDto);

        }

        //DELETE a studentdetails by iRoll

        [HttpDelete]
        [Route("{iRoll:int}")]

        public IActionResult Delete([FromRoute] int iRoll)
        {
            //Check if iRoll exist or not
            var studentDomainModel = dbContext.studentDetails.FirstOrDefault(x => x.iRoll == iRoll);

            if (studentDomainModel == null)
            {
                return NotFound();
            }
            //Delete Student
            dbContext.studentDetails.Remove(studentDomainModel);
            dbContext.SaveChanges();
            //if we want to see the deleted student details
            //Map Domain Model to DTO
            var studentDto = new StudentDetailsDto
            {
                iRoll = studentDomainModel.iRoll,
                CourseId = studentDomainModel.CourseId,
                FeesPaid = studentDomainModel.FeesPaid,
                DateJoined = studentDomainModel.DateJoined
            };

            return Ok(studentDto);


        }

    }
}
