using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.ServiceContracts.ViewModels.Teams;


namespace Tasks.Manager.ServiceContracts.Teams
{
    /// <summary>
    /// Interface for team entity
    /// </summary>
    public interface ITeamsService
    {
        Task<TeamViewModel> AddTeamAsync(AddTeamViewModel team, Guid createdByUser);
        Task<IEnumerable<TeamViewModel>> GetAllTeamsAsync();
        Task<TeamViewModel> GetTeamByIdAsync(Guid id);
        Task<bool> IsTeamNameExistAsync(string teamName);
        Task<TeamViewModel> UpdateTeamAsync(UpdateTeamViewModel team);
        Task<TeamViewModel> DeleteTeamAsync(TeamViewModel team);
    }
}
