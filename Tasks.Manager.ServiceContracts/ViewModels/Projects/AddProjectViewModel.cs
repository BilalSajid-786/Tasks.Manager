using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Manager.ServiceContracts.ViewModels.Projects
{
    public class AddProjectViewModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public Guid TeamId { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
