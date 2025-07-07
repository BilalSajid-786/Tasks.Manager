using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.Entities;

namespace Tasks.Manager.RepositoryContracts.Projects
{
    public interface IProjectsRepository
    {
        Task<Project> AddProjectAsync(Project project);
        Task<List<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectByIdAsync(Guid id);
        Task<bool> IsProjectNameExistAsync(string projectName);
        Task<Project> UpdateProjectAsync(Project project);
        Task<Project> DeleteProjectAsync(Project project);
    }
}
