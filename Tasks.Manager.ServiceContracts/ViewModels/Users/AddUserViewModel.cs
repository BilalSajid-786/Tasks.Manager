using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Manager.ServiceContracts.ViewModels.Users
{
    public class AddUserViewModel
    {
        [Required]
        public Guid UserId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        [Required]
        public bool IsSelected { get; set; }
    }
}

