using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.ServiceContracts.ViewModels.Users;

namespace Tasks.Manager.ServiceContracts.Users
{
    public interface IUserService
    {
        Task<IEnumerable<UserViewModel>> GetAvailableUsersAsync();
        Task UpdateUserAsync(IEnumerable<AddUserViewModel> addUserViewModels, Guid teamId);
    }
}
