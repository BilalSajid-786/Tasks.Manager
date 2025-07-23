using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.RepositoryContracts.Users
{
    public interface IUsersRepository
    {
        Task<IEnumerable<ApplicationUser>> GetAvailableUsersAsync();
        Task<bool> UpdateUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByIdAsync(Guid userId);
    }
}
