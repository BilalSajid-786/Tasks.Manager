using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasks.Manager.Entities.IdentityEntities;

namespace Tasks.Manager.Entities.Entities
{
    public class Project
    {
        [Key]
        public Guid ProjectId { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Foreign key property
        public Guid TeamId { get; set; }
        public Guid CreatedBy { get; set; }

        //Navigation property to Team, 1 project to 1 team
        [ForeignKey(nameof(TeamId))]
        public Team? Team { get; set; }

        //Navigation property to ApplicationUser
        [ForeignKey(nameof(CreatedBy))]
        public ApplicationUser? CreatedByUser { get; set; }

        //Navigation property to Task, 1 project to many tasks
        public ICollection<Task>? Tasks { get; set; }
    }
}
