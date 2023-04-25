using Final_Project_3045.Model;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_3045.Data
{
    public class HobbyInfoContext : DbContext
    {
        public HobbyInfoContext(DbContextOptions<HobbyInfoContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HobbyInfo>().HasData(
            new HobbyInfo
            {
                Id = 1,
                Outside = "Gardening",
                Indoor = "Gaming",
                Travel = "Swimming",
                Night = "Sit Outside",
                Weekend = "Shop"
            },
            new HobbyInfo
            {
                Id = 2,
                Outside = "Skiing",
                Indoor = "Gaming",
                Travel = "Exploring",
                Night = "Chilling",
                Weekend = "Movies"
            }        
            );
        }

        public DbSet<HobbyInfo> Hobbys { get; set; }
    }
}