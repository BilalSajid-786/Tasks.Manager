using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.Manager.ServiceContracts.ViewModels.Auth;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.Areas.Auth.Controllers
{
    [Area("Auth")]
    [Route("[area]/[controller]/[action]")]
    public class AccountController : Controller
    {
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(RoleManager<ApplicationRole> roleManager,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            //Preparing the roles dropdown for the registration
            var roles = _roleManager.Roles.Select(r => new SelectListItem()
            {
                Text = r.Name,
                Value = r.Id.ToString()
            });
            ViewBag.RolesList = roles;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel user)
        {

            //Check whether role exists
            var role = await _roleManager.FindByIdAsync(user.RoleId.ToString());
            if (role == null)
                return RedirectToAction(nameof(Register));

            var applicationUser = new ApplicationUser()
            {
                UserName = user.Name,
                Email = user.Email
            };

            var result = await _userManager.CreateAsync(applicationUser,user.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(applicationUser,role.Name);
            }

            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginRequest)
        {
            //Check user with the email exists in the system.
            var user = await _userManager.FindByEmailAsync(loginRequest.Email);
            if (user == null)
                return RedirectToAction(nameof(Login));

            //Login the user
            var result = await _signInManager.PasswordSignInAsync(user, loginRequest.Password, isPersistent: false, lockoutOnFailure: false);

            return RedirectToAction("Index","Home", new {area = ""});
        }
    }
}
