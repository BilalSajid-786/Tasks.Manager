using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.ServiceContracts.ViewModels.Users;

namespace Tasks.Manager.ServiceContracts.ViewModels.Teams
{
    public class AddTeamMemberViewModel
    {
        public IEnumerable<SelectListItem>? AvailableTeams { get; set; }
        public List<AddUserViewModel>? AvailableUsers { get; set; }
        public Guid TeamId { get; set; }
    }
}
