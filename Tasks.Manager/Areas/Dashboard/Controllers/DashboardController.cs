using Microsoft.AspNetCore.Mvc;

namespace Tasks.Manager.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Route("[area]/[controller]/[action]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
