using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tasks.Manager.Entities.Entities;

namespace Tasks.Manager.Entities.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        //Navigation Property to Team
        public ICollection<Team>? Teams { get; set; }

        //Navigation Property to Project
        public ICollection<Project>? Projects { get; set; }

        //Navigation Property to Task
        public ICollection<Entities.Task>? CreatedTasks { get; set; } = new List<Entities.Task>();

        //Navigation Property to Task
        public ICollection<Entities.Task>? AssignedTasks { get; set; }
    }
}
