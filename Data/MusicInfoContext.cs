using Final_Project_3045.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Final_Project_3045.Data
{
    public class MusicInfoContext : DbContext
    {

        public MusicInfoContext(DbContextOptions<MusicInfoContext> options) : base(options) { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("StudnetInfoContext");
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<MusicInfo>().HasData(
                new MusicInfo
                {
                    Id = 1,
                    Name = "Gabby",
                    Artist = "Green Day",
                    Song = "21st Century Breakdown",
                    Genre = "Rock",
                    Instrument = "Guitar"

                },
                new MusicInfo
                {
                    Id = 2,
                    Name = "William",
                    Artist = "Sawano Hiroyuki",
                    Song = "Nexus",
                    Genre = "Alternative",
                    Instrument = "Piano"
                });
        }

        public DbSet<MusicInfo> Musics { get; set; }
    }
}
