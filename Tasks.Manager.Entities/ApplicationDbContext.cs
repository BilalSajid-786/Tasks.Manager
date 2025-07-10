using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Team> Teams { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Entities.Task> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Configuring the relationship between Tasks and User
            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTasks)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Entities.Task>()
                .HasOne(t => t.AssignedToUser)
                .WithMany(u => u.AssignedTasks)
                .HasForeignKey(t => t.AssignedTo)
                .OnDelete(DeleteBehavior.Restrict);

            //Configuring the relationship between Project and Team
            modelBuilder.Entity<Project>()
                .HasOne(p => p.Team)
                .WithMany(t => t.Projects)
                .HasForeignKey(p => p.TeamId)
                .OnDelete(DeleteBehavior.Restrict);

            //CreatedBy property should be save only for one time for all entities.
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var createdBy = entityType.FindProperty("CreatedBy");

                if (createdBy is null)
                    continue;

                createdBy.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }

            //Data Seeding

            //Roles
            var adminRoleId = Guid.NewGuid();
            var managerRoleId = Guid.NewGuid();
            var employeeRoleId = Guid.NewGuid();

            modelBuilder.Entity<ApplicationRole>()
                .HasData(
                new ApplicationRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new ApplicationRole()
                {
                    Id = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new ApplicationRole()
                {
                    Id = employeeRoleId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );

            

        }
    }
}
