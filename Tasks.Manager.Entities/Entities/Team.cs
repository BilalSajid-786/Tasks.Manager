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
    public class Team
    {
        [Key]
        public Guid TeamId { get; set; }
        
        [Required]
        public string Name { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //Foreign key property
        public Guid CreatedBy { get; set; }

        //Navigation property to User for CreatedBy
        [ForeignKey(nameof(CreatedBy))]
        public ApplicationUser? CreatedByUser { get; set; }

        //Navigation Property to Projects
        public ICollection<Project>? Projects { get; set; }

        //Navigation Property to Users for Assigned Users
        public ICollection<ApplicationUser>? AssignedUsers { get; set; }

    }
}
