using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Tasks.Manager.Controllers
{
    public class BaseController : Controller
    {
        protected Guid LoggedInUserId => 
            Guid.Parse(HttpContext.User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.NameIdentifier)?.Value);
    }
}
