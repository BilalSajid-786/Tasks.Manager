using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.RepositoryContracts.Projects;
using Tasks.Manager.ServiceContracts.Projects;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;
using Tasks.Manager.Services.Projects.Mappers;

namespace Tasks.Manager.Services.Projects
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }
        public async Task<ProjectViewModel> AddProjectAsync(AddProjectViewModel project, Guid createdBy)
        {
            var projectEntityToAdd = ProjectsMapper.ToProject(project);
            projectEntityToAdd.CreatedBy = createdBy;
            var projectResponse = await _projectsRepository.AddProjectAsync(projectEntityToAdd);
            return ProjectsMapper.ToProjectViewModel(projectResponse);
        }

        public async Task<ProjectViewModel> DeleteProjectAsync(ProjectViewModel project)
        {
            var projectEntityToDelete = ProjectsMapper.ToProject(project);
            var projectDeleted = await _projectsRepository.DeleteProjectAsync(projectEntityToDelete);
            return ProjectsMapper.ToProjectViewModel(projectDeleted);
        }

        public async Task<IEnumerable<ProjectViewModel>> GetAllProjectsAsync()
        {
            var projects = await _projectsRepository.GetAllProjectsAsync();
            return projects.Select(p => ProjectsMapper.ToProjectViewModel(p));
        }

        public async Task<ProjectViewModel> GetProjectByIdAsync(Guid id)
        {
            var project = await _projectsRepository.GetProjectByIdAsync(id);
            return ProjectsMapper.ToProjectViewModel(project);
        }

        public async Task<bool> IsProjectNameExistAsync(string projectName)
        {
           return await _projectsRepository.IsProjectNameExistAsync(projectName);
        }

        public async Task<ProjectViewModel> UpdateProjectAsync(UpdateProjectViewModel project)
        {
            var projectById = await _projectsRepository.GetProjectByIdAsync(project.ProjectId);
            if(projectById != null)
            {
                var projectUpdated = await _projectsRepository.UpdateProjectAsync(projectById);
                return ProjectsMapper.ToProjectViewModel(projectUpdated);
            }
            return new ProjectViewModel();
        }
    }
}
