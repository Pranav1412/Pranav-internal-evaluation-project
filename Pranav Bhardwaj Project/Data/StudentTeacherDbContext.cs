using Microsoft.EntityFrameworkCore;
using StudentsComputerCentre.Models.Domain;

namespace StudentsComputerCentre.Data
{
    public class StudentTeacherDbContext:DbContext
    {

        public StudentTeacherDbContext(DbContextOptions dbContextOptions): base (dbContextOptions)
        {
            
        }

        public DbSet<CourseDetails> courses { get; set; }
        public DbSet<StudentDetails> studentDetails { get; set; }
        public DbSet<Students> studentes { get; set; }
        public DbSet<Teachers> teacherses { get; set; }
    }
}
