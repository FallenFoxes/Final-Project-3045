using Microsoft.EntityFrameworkCore;
using Final_Project_3045.models;

public class datacontext :DbContext
{
	public datacontext(DbContextOptions<datacontext> options) : base(options)
	{
	
	}

	public DbSet<InfoRequest> InfoTable { get; set; }
	public DbSet<HobbyRequest> HobbyTable { get; set; }

	public DbSet<MusicRequest> MusicTable { get; set; }
	public DbSet<GameRequest> GameTable { get; set; }
}
