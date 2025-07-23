using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities;
using Tasks.Manager.Entities.IdentityEntities;
using Tasks.Manager.RepositoryContracts.Users;

namespace Tasks.Manager.Repositories.Users
{
    public class UsersRepository : IUsersRepository
    {
        private readonly ApplicationDbContext _context;
        public UsersRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> UpdateUserAsync(ApplicationUser user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ApplicationUser>> GetAvailableUsersAsync()
        {
          return await _context.Users
                .Join(_context.UserRoles,
                u => u.Id,
                ur => ur.UserId,
                (u, ur) => new { u, ur })
                .Join(_context.Roles,
                u_ur => u_ur.ur.RoleId,
                r => r.Id,
                (u_ur, r) => new ApplicationUser()
                {
                    Id = u_ur.u.Id,
                    UserName = u_ur.u.UserName,
                    Email = u_ur.u.Email,
                    Role = r.Name,
                    TeamId = u_ur.u.TeamId,
                })
                .Where(u => u.TeamId==null && u.Role!="Admin")
                .ToListAsync();
        }

        public async Task<ApplicationUser> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.SingleAsync(u => u.Id == userId);
        }
    }
}
