using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.RepositoryContracts.Users;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.Users;
using Tasks.Manager.ServiceContracts.ViewModels.Users;
using Tasks.Manager.Services.Users.Mappers;

namespace Tasks.Manager.Services.Users
{
    public class UsersService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly ITeamsService _teamsService;
        public UsersService(IUsersRepository usersRepository, ITeamsService teamsService)
        {
            _usersRepository = usersRepository;
            _teamsService = teamsService;
        }
        public async Task<IEnumerable<UserViewModel>> GetAvailableUsersAsync()
        {
            var users = await _usersRepository.GetAvailableUsersAsync();
            return users.Select(u => UsersMapper.ToUserViewModel(u));
        }

        public async Task UpdateUserAsync(IEnumerable<AddUserViewModel> addUserViewModels, Guid teamId)
        {
            foreach (var user in addUserViewModels)
            {
                var applicationUser = await _usersRepository.GetUserByIdAsync(user.UserId);
                if(applicationUser is not null)
                {
                    var team = await _teamsService.GetTeamByIdAsync(teamId);
                    if(team is not null)
                    {
                        applicationUser.TeamId = teamId;
                        await _usersRepository.UpdateUserAsync(applicationUser);
                    }
                }
            }
        }
    }
}
