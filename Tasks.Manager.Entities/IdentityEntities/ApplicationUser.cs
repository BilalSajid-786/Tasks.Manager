using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Tasks.Manager.Entities.Entities;

namespace Tasks.Manager.Entities.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //ForeignKey to Team Table
        public Guid? TeamId { get; set; }

        //Navigation Property to Team 1 team - * assignedUsers
        [ForeignKey(nameof(TeamId))]
        public Team? Team { get; set; }

        //Navigation Property to Task
        public ICollection<Entities.Task>? CreatedTasks { get; set; } = new List<Entities.Task>();

        //Navigation Property to Task
        public ICollection<Entities.Task>? AssignedTasks { get; set; }

        //Navigation Property to Team 1 user - * createdTeams
        public ICollection<Team>? CreatedTeams { get; set; }

        //Navigation Property to Projects
        public ICollection<ProjectUser>? ProjectUsers { get; set; }
    }
}
