using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsComputerCentre.Data;
using StudentsComputerCentre.Models.Domain;
using StudentsComputerCentre.Models.DTO;

namespace StudentsComputerCentre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseDetailsController : ControllerBase
    {
       
            private readonly StudentTeacherDbContext dbContext;

            public CourseDetailsController(StudentTeacherDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

        //GET All CourseDetails
        [HttpGet]
            public IActionResult GetAll()
            {
                var studentsDomain = dbContext.courses.ToList();
                //Map Domain Models to DTO
                var studentsDto = new List<CourseDetailsDto>();
                foreach (var studentDomain in studentsDomain)
                {
                    studentsDto.Add(new CourseDetailsDto()
                    {
                        CourseId = studentDomain.CourseId,
                        CourseName = studentDomain.CourseName,
                        Fees = studentDomain.Fees
                    });
                }
                return Ok(studentsDomain);
            }

        //GET Single StudentDetails by CourseId
        [HttpGet]
            [Route("{CourseId:int}")]
            public IActionResult GetbyiRoll([FromRoute] int CourseId)
            {

                var studentDomain = dbContext.courses.FirstOrDefault(x => x.CourseId == CourseId);
                if (studentDomain == null)
                {
                    return NotFound();
                }

                //Convert Student Domain Model to Studnet Dto
                var studentDto = new CourseDetailsDto
                {

                    CourseId = studentDomain.CourseId,
                    CourseName = studentDomain.CourseName,
                    Fees = studentDomain.Fees
                };

                return Ok(studentDto);
            }


            //POST to Create new StudentDetails
            [HttpPost]
            public IActionResult Create([FromBody] AddCourseDetailsRequestDto addCourseDetailsRequestDto)
            {
                //Map DTO to Domain Model
                var studentDomainModel = new CourseDetails
                {
                   
                    CourseId = addCourseDetailsRequestDto.CourseId,
                    CourseName = addCourseDetailsRequestDto.CourseName,
                    Fees = addCourseDetailsRequestDto.Fees
                };

                //Use DOmain Model to Create Student
                dbContext.courses.Add(studentDomainModel);
                dbContext.SaveChanges();

                //Map Domain Model Back to DTO
                var studentDto = new CourseDetailsDto
                {
                  
                    CourseId = studentDomainModel.CourseId,
                    CourseName = studentDomainModel.CourseName,
                    Fees = studentDomainModel.Fees
                };

                return CreatedAtAction(nameof(GetbyiRoll), new { courseId = studentDto.CourseId }, studentDto);
            }

            //PUT to Update a StudentDetails

            [HttpPut]
            [Route("{CourseId:int}")]

            public IActionResult Update([FromRoute] int CourseId, [FromBody] UpdateCourseDetailsRequestDto updateCourseDetailsRequestDto)
            {
                //Check if Student iRoll Exists
                var studentDomainModel = dbContext.courses.FirstOrDefault(x => x.CourseId == CourseId);

                if (studentDomainModel == null)
                {
                    return NotFound();
                }

                //Map DTO to Domain Model

               
                studentDomainModel.CourseId = updateCourseDetailsRequestDto.CourseId;
                studentDomainModel.CourseName = updateCourseDetailsRequestDto.CourseName;
                studentDomainModel.Fees = updateCourseDetailsRequestDto.Fees;

                dbContext.SaveChanges();

                //Convert Domain Model to DTO

                var studentDto = new CourseDetailsDto
                {
                  
                    CourseId = studentDomainModel.CourseId,
                    CourseName = studentDomainModel.CourseName,
                    Fees = studentDomainModel.Fees
                };

                return Ok(studentDto);

            }

            //DELETE a studentdetails by iRoll

            [HttpDelete]
            [Route("{CourseId:int}")]

            public IActionResult Delete([FromRoute] int CourseId)
            {
            //Check if CourseId exist or not
            var studentDomainModel = dbContext.courses.FirstOrDefault(x => x.CourseId == CourseId);

                if (studentDomainModel == null)
                {
                    return NotFound();
                }
                //Delete Student
                dbContext.courses.Remove(studentDomainModel);
                dbContext.SaveChanges();
                //if we want to see the deleted student details
                //Map Domain Model to DTO
                var studentDto = new CourseDetailsDto
                {
                  
                    CourseId = studentDomainModel.CourseId,
                    CourseName = studentDomainModel.CourseName,
                    Fees = studentDomainModel.Fees
                };

                return Ok(studentDto);


            }
        }
}
