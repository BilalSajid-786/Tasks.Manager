using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasks.Manager.Controllers;

namespace Tasks.Manager.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("[area]/[controller]/[action]")]
    public class DashboardController : BaseController
    {
        [Authorize(Roles = "Admin,Manager,Employee")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
