using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities;
using Tasks.Manager.Entities.Entities;
using Tasks.Manager.RepositoryContracts.Teams;

namespace Tasks.Manager.Repositories.Teams
{
    public class TeamsRepository : ITeamsRepository
    {
        private readonly ApplicationDbContext _context;
        public TeamsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Team> AddTeamAsync(Team team)
        {
            await _context.Teams.AddAsync(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<Team> GetTeamByIdAsync(Guid teamId)
        {
            return await _context.Teams.AsNoTracking().FirstAsync(t => t.TeamId == teamId);
        }

        public async Task<Team> DeleteTeamAsync(Team team)
        {
            _context.Teams.Remove(team);
            await _context.SaveChangesAsync();
            return team;
        }

        public async Task<List<Team>> GetAllTeamsAsync()
        {
            return await _context.Teams.Include(t => t.CreatedByUser).ToListAsync();
        }

        public async Task<bool> IsTeamNameExistAsync(string teamName)
        {
            return await _context.Teams.AnyAsync(t => t.Name == teamName);
        }

        public async Task<Team> UpdateTeamAsync(Team team)
        {
            var entity = await _context.Teams.AsNoTracking().FirstAsync(t => t.TeamId == team.TeamId);
            team.CreatedBy = entity.CreatedBy;
            if(entity != null)
            {
                _context.Teams.Update(team);
                await _context.SaveChangesAsync();
            }
            return team;
        }
    }
}
