using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsComputerCentre.Data;
using StudentsComputerCentre.Models.Domain;
using StudentsComputerCentre.Models.DTO;

namespace StudentsComputerCentre.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly StudentTeacherDbContext dbContext;

        public TeachersController(StudentTeacherDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GET All Teacher
        [HttpGet]
        public IActionResult GetAll()
        {
            var teachersDomain = dbContext.teacherses.ToList();
            //Map Domain Models to DTO
            var teachersDto = new List<TeachersDto>();
            foreach (var teacherDomain in teachersDomain)
            {
                teachersDto.Add(new TeachersDto()
                {
                    TeacherId = teacherDomain.TeacherId,
                    TeacherName = teacherDomain.TeacherName
                });
            }
            return Ok(teachersDomain);
        }

        //GET Single Teacher by TeacherId
        [HttpGet]
        [Route("{TeacherId:int}")]
        public IActionResult GetbyTeacherId([FromRoute] int TeacherId)
        {

            var teacherDomain = dbContext.teacherses.FirstOrDefault(x => x.TeacherId == TeacherId);
            if (teacherDomain == null)
            {
                return NotFound();
            }

            //Convert Student Domain Model to Studnet Dto
            var teacherDto = new TeachersDto
            {
                TeacherId = teacherDomain.TeacherId,
                TeacherName = teacherDomain.TeacherName
            };

            return Ok(teacherDto);
        }


        //POST to Create new Teacher
        [HttpPost]
        public IActionResult Create([FromBody] AddTeacherRequestDto addTeacherRequestDto)
        {
            //Map DTO to Domain Model
            var teacherDomainModel = new Teachers
            {
                TeacherId = addTeacherRequestDto.TeacherId,
                TeacherName = addTeacherRequestDto.TeacherName
            };

            //Use DOmain Model to Create Teachers
            dbContext.teacherses.Add(teacherDomainModel);
            dbContext.SaveChanges();

            //Map Domain Model Back to DTO
            var teacherDto = new TeachersDto
            {
                TeacherId = teacherDomainModel.TeacherId,
                TeacherName = teacherDomainModel.TeacherName
            };

            return CreatedAtAction(nameof(GetbyTeacherId), new { teacherId = teacherDto.TeacherId }, teacherDto);
        }

        //PUT to Update a Teacher

        [HttpPut]
        [Route("{TeacherId:int}")]

        public IActionResult Update([FromRoute] int TeacherId, [FromBody] UpdateTeacherRequestDto updateTeacherRequestDto)
        {
            //Check if Teacher iRoll Exists
            var teacherDomainModel = dbContext.teacherses.FirstOrDefault(x => x.TeacherId == TeacherId);

            if (teacherDomainModel == null)
            {
                return NotFound();
            }

            //Map DTO to Domain Model

            teacherDomainModel.TeacherId = updateTeacherRequestDto.TeacherId;
            teacherDomainModel.TeacherName = updateTeacherRequestDto.TeacherName;

            dbContext.SaveChanges();

            //Convert Domain Model to DTO

            var teacherDto = new TeachersDto
            {
                TeacherId = teacherDomainModel.TeacherId,
                TeacherName = teacherDomainModel.TeacherName
            };

            return Ok(teacherDto);

        }

        //DELETE a Teacher by TeacherId

        [HttpDelete]
        [Route("{TeacherId:int}")]

        public IActionResult Delete([FromRoute] int TeacherId)
        {
            //Check if TeacherId exist or not
            var teacherDomainModel = dbContext.teacherses.FirstOrDefault(x => x.TeacherId == TeacherId);

            if (teacherDomainModel == null)
            {
                return NotFound();
            }
            //Delete Teacher
            dbContext.teacherses.Remove(teacherDomainModel);
            dbContext.SaveChanges();
            //if we want to see the deleted Teacher details
            //Map Domain Model to DTO
            var teacherDto = new TeachersDto
            {
                TeacherId = teacherDomainModel.TeacherId,
                TeacherName = teacherDomainModel.TeacherName
            };

            return Ok(teacherDto);


        }

    }
}
