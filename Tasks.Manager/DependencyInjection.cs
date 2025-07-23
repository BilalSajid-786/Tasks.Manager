using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.Manager.Entities;
using Tasks.Manager.Entities.IdentityEntities;
using Tasks.Manager.Repositories.Projects;
using Tasks.Manager.Repositories.Teams;
using Tasks.Manager.Repositories.Users;
using Tasks.Manager.RepositoryContracts.Projects;
using Tasks.Manager.RepositoryContracts.Teams;
using Tasks.Manager.RepositoryContracts.Users;
using Tasks.Manager.ServiceContracts.Projects;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.Users;
using Tasks.Manager.Services.Projects;
using Tasks.Manager.Services.Teams;
using Tasks.Manager.Services.Users;

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
            services.AddTransient<IProjectsService, ProjectsService>();
            services.AddTransient<IUserService, UsersService>();

            //Repositories
            services.AddTransient<ITeamsRepository,TeamsRepository>();
            services.AddTransient<IProjectsRepository, ProjectsRepository>();
            services.AddTransient<IUsersRepository, UsersRepository>();

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
