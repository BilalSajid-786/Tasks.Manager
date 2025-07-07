using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasks.Manager.ServiceContracts.ViewModels.Teams
{
    public class AddTeamViewModel
    {
        [Required]
        [Remote(action:"IsTeamNameAvailable",
            areaName:"Teams",
            controller:"Teams",
            ErrorMessage = "A team with this name already exists")]
        public string Name { get; set; } = string.Empty;
    }
}
