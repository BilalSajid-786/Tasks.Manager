using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Tasks.Manager.ServiceContracts.Projects;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;

namespace Tasks.Manager.Areas.Projects.Controllers
{
    [Area("Projects")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectsController : Controller
    {
        private readonly ITeamsService _teamsService;
        private readonly IProjectsService _projectsService;
        public ProjectsController(ITeamsService teamsService, IProjectsService projectsService)
        {
            _teamsService = teamsService;
            _projectsService = projectsService;
        }
        public async Task<IActionResult> Index()
        {
            var projects = await _projectsService.GetAllProjectsAsync();
            return View(projects);
        }

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

        [HttpPost]
        public async Task<IActionResult> Add(AddProjectViewModel project)
        {
            if(!ModelState.IsValid)
            {
                return View(project);
            }
            var userId = HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value;
            var projectViewModel = await _projectsService.AddProjectAsync(project,Guid.Parse(userId));
            return RedirectToAction("Index", "Projects", new { area = "Projects" });
        }
    }
}
