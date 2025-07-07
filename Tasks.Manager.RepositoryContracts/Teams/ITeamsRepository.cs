using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.Entities;

namespace Tasks.Manager.RepositoryContracts.Teams
{
    public interface ITeamsRepository
    {
        Task<Team> AddTeamAsync(Team team);
        Task<List<Team>> GetAllTeamsAsync();
        Task<Team> GetTeamByIdAsync(Guid id);
        Task<bool> IsTeamNameExistAsync(string teamName);
        Task<Team> UpdateTeamAsync(Team team);
        Task<Team> DeleteTeamAsync(Team team);
    }
}
