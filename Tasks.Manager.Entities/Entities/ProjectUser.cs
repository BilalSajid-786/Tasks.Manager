using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.Entities.Entities
{
    public class ProjectUser
    {
        public Guid UserId { get; set; }
        public Guid ProjectId { get; set; }

        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser? User { get; set; }
    }
}
