using Final_Project_3045.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

public void ConfigureServices(IServiceCollection services)
{
    services.AddControllers();
    services.AddDbContext<StudentInfoContext>(options =>
        options.UseSqlServer(Configuration.GetConnectionsString("StudentInfoContext")));
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StudentInfoContext)
{
    if (env.IsDevelopment())
    { app.UseDeveloperExceptionPage(); }

    Context.Database.Migrate();

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthorization();

    app.UseEndpoints(endpoints =>
    {
        endpoints.MapControllers();
    });

    app.MapControllers();

    app.Run();
}
