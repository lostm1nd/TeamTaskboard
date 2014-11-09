namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public ICollection<TeamTask> Tasks { get; set; }
    }
}
