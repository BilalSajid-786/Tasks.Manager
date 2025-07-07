using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Manager.ServiceContracts.ViewModels.Teams
{
    public class TeamViewModel
    {
        public Guid TeamId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? CreatedBy { get; set; }
    }
}
