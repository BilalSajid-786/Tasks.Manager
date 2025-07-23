using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.IdentityEntities;
using Tasks.Manager.ServiceContracts.ViewModels.Users;

namespace Tasks.Manager.Services.Users.Mappers
{
    public class UsersMapper
    {
        ////Entity to ViewModel
        public static UserViewModel ToUserViewModel(ApplicationUser user)
        {
            return new UserViewModel()
            {
                UserId = user.Id,
                Name = user.UserName,
                Email = user.Email,
                Role = user.Role
            };
        }

        ////ViewModel to AddViewModel
        public static AddUserViewModel ToAddUserViewModel(UserViewModel user)
        {
            return new AddUserViewModel()
            {
                UserId = user.UserId,
                Name = user.Name,
                Email = user.Email,
                Role = user.Role
            };
        }
    }
}
