using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Final_Project_3045.Data;
using Microsoft.Data.SqlClient;
using Final_Project_3045.Interfaces;

namespace Final_Project_3045
{

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        
        public void ConfigureServices(IServiceCollection services)
        {
            // Student Info Services
            services.AddDbContext<StudentInfoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StudentInfoContext")));
            services.AddScoped<IStudentInfoContextDAO, StudentInfoContextDAO>();

            //Game Info Services
            services.AddDbContext<GameInfoContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("StudentInfoContext")));

            services.AddControllers();

        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, StudentInfoContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }
            context.Database.Migrate();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

