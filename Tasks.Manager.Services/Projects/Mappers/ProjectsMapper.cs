using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;
using Tasks.Manager.ServiceContracts.ViewModels.Teams;

namespace Tasks.Manager.Services.Projects.Mappers
{
    public static class ProjectsMapper
    {
        //Entity to ViewModel
        public static ProjectViewModel ToProjectViewModel(Project project)
        {
            return new ProjectViewModel()
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                Team = project?.Team?.Name
            };
        }


        //ViewModel to Entity
        public static Project ToProject(object project)
        {
            if (project is ProjectViewModel projectViewModel)
            {
                return new Project()
                {
                    ProjectId = projectViewModel.ProjectId,
                    Name = projectViewModel.Name,
                    Description = projectViewModel.Description,
                    CreatedAt = projectViewModel.CreatedAt
                };
            }
            if (project is AddProjectViewModel addProjectViewModel)
            {
                return new Project()
                {
                    Name = addProjectViewModel.Name,
                    Description = addProjectViewModel.Description,
                    CreatedAt = addProjectViewModel.CreatedAt,
                    TeamId = addProjectViewModel.TeamId
                };
            }
            if (project is UpdateProjectViewModel updateProjectViewModel)
            {
                return new Project()
                {
                    ProjectId = updateProjectViewModel.ProjectId,
                    Name = updateProjectViewModel.Name,
                    Description = updateProjectViewModel.Description
                };
            }
            return new Project();
        }

    }
}
