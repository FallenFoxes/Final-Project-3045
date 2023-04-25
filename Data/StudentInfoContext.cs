using Final_Project_3045.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Final_Project_3045.Data
{
    public class StudentInfoContext : DbContext
    {

        public StudentInfoContext(DbContextOptions<StudentInfoContext> options) :base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("StudentInfoContext");
        }
        protected override void OnModelCreating(ModelBuilder builder) 
        {         
            builder.Entity<StudentInfo>().HasData(
                new StudentInfo
                {
                    Id = 1,
                    FirstName = "William",
                    LastName = "Bohman",
                    Birthday = "09/25/96",
                    CollegeProgram = "Software Dev",
                    ProgramYear = "2024"
                },
                new StudentInfo
                { 
                    Id = 2,
                    FirstName = "Gabby",
                    LastName = "McClimans",
                    Birthday = "10/05/2000",
                    CollegeProgram = "Game Dev/Software Dev",
                    ProgramYear = "2025"}
                );
        }

        public DbSet<StudentInfo> Students { get; set; }       
    }
}
