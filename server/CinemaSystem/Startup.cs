using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CinemaSystem.Database;
using CinemaSystem.Repositories;
using CinemaSystem.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace CinemaSystem
{
    public class Startup
    {
        private bool InDocker { get { return Environment.GetEnvironmentVariable("DOTNET_RUNNING_IN_CONTAINER") == "true"; } }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<CinemaDbContext>(options =>
            {
                string connectionString = InDocker ? Configuration.GetConnectionString("DefaultConnection") : Configuration.GetConnectionString("MigrationConnection");
                options.UseNpgsql(connectionString);
            });

            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IMoviesRepository, MoviesRepository>();
            services.AddScoped<IHalesRepository, HalesRepository>();
            services.AddScoped<IReservationsRepository, ReservationsRepository>();
            services.AddScoped<IShowingsRepository, ShowingsRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IUsersService, UsersService>();
            services.AddScoped<IMoviesService, MoviesService>();
            services.AddScoped<IHalesService, HalesService>();
            services.AddScoped<IShowingsService, ShowingsService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cinema System API");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                serviceScope.ServiceProvider.GetService<CinemaDbContext>().Database.Migrate();
            }

            app.UseCors("AllowAll");

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
