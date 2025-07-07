using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.RepositoryContracts.Projects;

namespace Tasks.Manager.Repositories.Projects
{
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApplicationDbContext _context;
        public ProjectsRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Project> AddProjectAsync(Project project)
        {
            await _context.Projects.AddAsync(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<Project> DeleteProjectAsync(Project project)
        {
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return project;
        }

        public async Task<List<Project>> GetAllProjectsAsync()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<Project> GetProjectByIdAsync(Guid id)
        {
            return await _context.Projects.FindAsync(id);
        }

        public async Task<bool> IsProjectNameExistAsync(string projectName)
        {
            return await _context.Projects.AnyAsync(p => p.Name == projectName);
        }

        public async Task<Project> UpdateProjectAsync(Project project)
        {
            _context.Projects.Update(project);
            await _context.SaveChangesAsync();
            return project;
        }
    }
}
