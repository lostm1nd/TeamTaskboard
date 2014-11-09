namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<TaskboardUser>();
            this.Projects = new HashSet<Project>();
        }

        [Key]
        public int TeamId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<TaskboardUser> Members { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }
}
