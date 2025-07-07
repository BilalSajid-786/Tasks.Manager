using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.RepositoryContracts.Teams;
using Tasks.Manager.ServiceContracts.Teams;
using Tasks.Manager.ServiceContracts.ViewModels.Teams;
using Tasks.Manager.Services.Teams.Mappers;

namespace Tasks.Manager.Services.Teams
{
    public class TeamsService : ITeamsService
    {
        private readonly ITeamsRepository _teamsRepository;
        public TeamsService(ITeamsRepository teamsRepository)
        {
            _teamsRepository = teamsRepository;
        }
        public async Task<TeamViewModel> AddTeamAsync(AddTeamViewModel team, Guid createdByUser)
        {
            Team teamToAdd = TeamsMapper.ToTeam(team);
            teamToAdd.CreatedBy = createdByUser;
            var teamEntity = await _teamsRepository.AddTeamAsync(teamToAdd);
            return TeamsMapper.ToTeamViewModel(teamEntity);
        }

        public async Task<TeamViewModel> DeleteTeamAsync(TeamViewModel team)
        {
            Team teamToDelete = TeamsMapper.ToTeam(team);
            var teamEntityRemoved = await _teamsRepository.DeleteTeamAsync(teamToDelete);
            return TeamsMapper.ToTeamViewModel(teamEntityRemoved);
        }

        public async Task<IEnumerable<TeamViewModel>> GetAllTeamsAsync()
        {
            var teams = await _teamsRepository.GetAllTeamsAsync();
            var teamViewModelList = teams.Select(t => TeamsMapper.ToTeamViewModel(t));
            return teamViewModelList;
        }

        public async Task<TeamViewModel> GetTeamByIdAsync(Guid id)
        {
            var team = await _teamsRepository.GetTeamByIdAsync(id);
            return TeamsMapper.ToTeamViewModel(team);
        }

        public async Task<bool> IsTeamNameExistAsync(string teamName)
        {
            return await _teamsRepository.IsTeamNameExistAsync(teamName);
        }

        public async Task<TeamViewModel> UpdateTeamAsync(UpdateTeamViewModel team)
        {
            var teamToUpdate = TeamsMapper.ToTeam(team);
            var teamEntityUpdated = await _teamsRepository.UpdateTeamAsync(teamToUpdate);
            return TeamsMapper.ToTeamViewModel(teamToUpdate);
        }

    }
}
