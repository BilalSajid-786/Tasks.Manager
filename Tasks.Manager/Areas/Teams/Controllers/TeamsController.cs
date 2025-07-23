using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasks.Manager.Controllers;
using Tasks.Manager.Entities.IdentityEntities;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.Users;
using Tasks.Manager.ServiceContracts.ViewModels.Teams;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tasks.Manager.ServiceContracts.ViewModels.Users;
using Tasks.Manager.Services.Users.Mappers;

namespace Tasks.Manager.Areas.Teams.Controllers
{
    [Area("Teams")]
    [Route("[area]/[controller]/[action]")]
    public class TeamsController : BaseController
    {
        private readonly ITeamsService _teamsService;
        private readonly IUserService _usersService;
        public TeamsController(ITeamsService teamsService, IUserService usersService)
        {
            _teamsService = teamsService;
            _usersService = usersService;
        }

        [Authorize(Roles = "Admin,Manager")]
        public async Task<IActionResult> Index()
        {
            var teams = await _teamsService.GetAllTeamsAsync();
            return View(teams);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add(AddTeamViewModel addTeamViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addTeamViewModel);
            }
            await _teamsService.AddTeamAsync(addTeamViewModel,LoggedInUserId);
            return RedirectToAction("Index","Teams", new {area = "Teams"});
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(Guid teamId)
        {
            var team = await _teamsService.GetTeamByIdAsync(teamId);
            if(team is null)
            {
                return RedirectToAction("Index", "Teams", new { area = "Teams" });
            }
            UpdateTeamViewModel teamViewModel = new UpdateTeamViewModel()
            {
                Name = team.Name,
                TeamId = team.TeamId
            };
            return View(teamViewModel);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(UpdateTeamViewModel updateTeamViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(updateTeamViewModel);
            }
            await _teamsService.UpdateTeamAsync(updateTeamViewModel);
            return RedirectToAction("Index", "Teams", new { area = "Teams" });
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(Guid teamId)
        {
            var team = await _teamsService.GetTeamByIdAsync(teamId);
            if (team is not null)
            {
                await _teamsService.DeleteTeamAsync(team);
            }
            return RedirectToAction("Index", "Teams", new { area = "Teams" });
        }
        public async Task<IActionResult> IsTeamNameAvailable(string Name) 
        {
            var teamExist = await _teamsService.IsTeamNameExistAsync(Name);
            return Ok(!teamExist);
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AssignMembers()
        {
            var users = await _usersService.GetAvailableUsersAsync();
            var teams = await _teamsService.GetAllTeamsAsync();


            AddTeamMemberViewModel addTeamMemberViewModel = new AddTeamMemberViewModel()
            {
                AvailableUsers = users.Select(u => UsersMapper.ToAddUserViewModel(u)).ToList(),
                AvailableTeams = teams.Select(t => new SelectListItem()
                {
                    Text = t.Name,
                    Value = t.TeamId.ToString()
                })
            };

            return View(addTeamMemberViewModel);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AssignMembers(AddTeamMemberViewModel addTeamMemberViewModel)
        {
            var assignedTeamMembers = addTeamMemberViewModel?.AvailableUsers?.Where(u => u.IsSelected == true);
            await _usersService.UpdateUserAsync(assignedTeamMembers, addTeamMemberViewModel.TeamId);
            return RedirectToAction("Index", "Dashboard", new { area = "Dashboard" });
        }

    }
}
