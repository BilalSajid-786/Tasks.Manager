using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;

namespace Tasks.Manager.ServiceContracts.Projects
{
    public interface IProjectsService
    {
        Task<ProjectViewModel> AddProjectAsync(AddProjectViewModel project);
        Task<List<ProjectViewModel>> GetAllProjectsAsync();
        Task<ProjectViewModel> GetProjectByIdAsync(Guid id);
        Task<bool> IsProjectNameExistAsync(string projectName);
        Task<ProjectViewModel> UpdateProjectAsync(UpdateProjectViewModel project);
        Task<ProjectViewModel> DeleteProjectAsync(ProjectViewModel project);
    }
}
