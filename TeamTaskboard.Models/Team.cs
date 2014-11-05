namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Team
    {
        public Team()
        {
            this.Members = new HashSet<User>();
            this.Tasks = new HashSet<TeamTask>();
            this.Statuses = new HashSet<Status>();
        }

        public int TeamId { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual User TeamLeader { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<TeamTask> Tasks { get; set; }

        public virtual ICollection<Status> Statuses { get; set; }
    }
}
