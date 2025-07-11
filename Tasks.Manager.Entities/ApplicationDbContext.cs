using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.Entities
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
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

            //Configuring the relationship between Teams and Users
            modelBuilder.Entity<Team>()
                .HasOne(t => t.CreatedByUser)
                .WithMany(u => u.CreatedTeams)
                .HasForeignKey(t => t.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ApplicationUser>()
                .HasOne(u => u.Team)
                .WithMany(t => t.AssignedUsers)
                .HasForeignKey(u => u.TeamId);

            //Configuring the relationship between Projects and Users

            modelBuilder.Entity<ProjectUser>()
                .HasKey(pu => new { pu.ProjectId, pu.UserId });   // composite PK

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.Project)
                .WithMany(p => p.ProjectUsers)
                .HasForeignKey(pu => pu.UserId);

            modelBuilder.Entity<ProjectUser>()
                .HasOne(pu => pu.User)
                .WithMany(u => u.ProjectUsers)
                .HasForeignKey(u => u.ProjectId)
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
            var adminRoleId = Guid.Parse("08093A5D-C984-41FA-8E6E-C07A1253C06B");
            var managerRoleId = Guid.Parse("09D3AE68-CA13-4D6E-BD86-F0773439DC8A");
            var employeeRoleId = Guid.Parse("41E70C2A-B383-4AEF-93EE-03B3423A3596");

            modelBuilder.Entity<ApplicationRole>()
                .HasData(
                new ApplicationRole()
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = "db051222-4d68-40ab-aed0-7ba1b3aca26e"
                },
                new ApplicationRole()
                {
                    Id = managerRoleId,
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = "2308c8bd-4c88-480c-83f2-c3d34dbdd3a9"
                },
                new ApplicationRole()
                {
                    Id = employeeRoleId,
                    Name = "Employee",
                    NormalizedName = "EMPLOYEE",
                    ConcurrencyStamp = "69261fa8-6ea9-48cf-88a0-3dbe538c4d5c"
                }
                );



        }
    }
}
