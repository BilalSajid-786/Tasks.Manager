using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Tasks.Manager.Controllers;
using Tasks.Manager.ServiceContracts.Projects;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;

namespace Tasks.Manager.Areas.Projects.Controllers
{
    [Area("Projects")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectsController : BaseController
    {
        private readonly ITeamsService _teamsService;
        private readonly IProjectsService _projectsService;
        public ProjectsController(ITeamsService teamsService, IProjectsService projectsService)
        {
            _teamsService = teamsService;
            _projectsService = projectsService;
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            return View(projects);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add()
        {
            var teams = await _teamsService.GetAllTeamsAsync();
            ViewBag.TeamsList = teams.Select(t => new SelectListItem()
            {
                Text = t.Name,
                Value = t.TeamId.ToString()
            });
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Add(AddProjectViewModel project)
        {
            if(!ModelState.IsValid)
            {
                return View(project);
            }
            var projectViewModel = await _projectsService.AddProjectAsync(project,LoggedInUserId);
            return RedirectToAction("Index", "Projects", new { area = "Projects" });
        }


        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid projectId)
        {
            var project = await _projectsService.GetProjectByIdAsync(projectId);
            if (project is null)
                return RedirectToAction("Index", "Projects", new { area = "Projects" });

            //drop down for teams.
            var teams = await _teamsService.GetAllTeamsAsync();
            
            ViewBag.TeamsList = teams.Select(t => new SelectListItem()
            {
                Text = t.Name,
                Value = t.TeamId.ToString()
            });

            UpdateProjectViewModel projectViewModel = new UpdateProjectViewModel()
            {
                ProjectId = project.ProjectId,
                Name = project.Name,
                Description = project.Description,
                TeamId = project.TeamId
            };

            return View(projectViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProjectViewModel updateProjectViewModel)
        {
            await _projectsService.UpdateProjectAsync(updateProjectViewModel);
            return RedirectToAction("Index", "Projects", new { area = "Projects" });
        }

        public async Task<IActionResult> Delete(Guid projectId)
        {
            var projectToDelete = await _projectsService.GetProjectByIdAsync(projectId);
            await _projectsService.DeleteProjectAsync(projectToDelete);
            return RedirectToAction("Index", "Projects", "Projects");
        }
    }
}
