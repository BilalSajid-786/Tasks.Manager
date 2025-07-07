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
    public class Task
    {
        [Key]
        public Guid TaskId { get; set; }
        
        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        //Foreign key property
        public Guid CreatedBy { get; set; }
        public Guid AssignedTo { get; set; }
        public Guid ProjectId { get; set; }

        //Navigation Property to User
        [ForeignKey(nameof(CreatedBy))]
        public ApplicationUser? CreatedByUser { get; set; }

        //Navigation Property to User
        [ForeignKey(nameof(AssignedTo))]
        public ApplicationUser? AssignedToUser { get; set; }

        //Navigation Property to Project
        [ForeignKey(nameof(ProjectId))]
        public Project? Project { get; set; }
    }
}
