using Microsoft.AspNetCore.Mvc;
using Tasks.Manager.ServiceContracts.ViewModels.Projects;

namespace Tasks.Manager.Areas.Projects.Controllers
{
    [Area("Projects")]
    [Route("[area]/[controller]/[action]")]
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View(new List<ProjectViewModel>());
        }
    }
}
