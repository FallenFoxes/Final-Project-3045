using Final_Project_3045.Model;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_3045.Data
{
    public class GameInfoContext : DbContext
    {
        public GameInfoContext(DbContextOptions<GameInfoContext> options) :base(options) { }    

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<GameInfo>().HasData(new GameInfo
            {
                Id = 1,
                Game = "Destiny 2",
                Company = "Bungie",
                Platform = "PC",
                Streamer = "Panduh",
                Character = "Cayde-6"
            });
        }

        public DbSet<GameInfo> Games { get; set; }
    }
}
