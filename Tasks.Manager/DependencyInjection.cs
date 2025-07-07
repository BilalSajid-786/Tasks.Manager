using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.Manager.Entities;
using Tasks.Manager.Entities.IdentityEntities;
using Tasks.Manager.Repositories.Teams;
using Tasks.Manager.RepositoryContracts.Teams;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.Services.Teams;

namespace Tasks.Manager
{
    public static class DependencyInjection
    {
        public static IServiceCollection ConfigureAppServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services to the container.

            //Controllers
            services.AddControllersWithViews();

            //Services
            services.AddTransient<ITeamsService, TeamsService>();

            //Repositories
            services.AddTransient<ITeamsRepository,TeamsRepository>();


            //DbContext
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });

            //Identity Context
            services.AddIdentity<ApplicationUser, ApplicationRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();

            return services;
        }
    }
}
