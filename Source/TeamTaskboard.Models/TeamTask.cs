﻿namespace TeamTaskboard.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamTask
    {
        public TeamTask()
        {
            this.Comments = new HashSet<Comment>();
        }

        [Key]
        public int TeamTaskId { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; }

        public virtual TaskboardUser Reporter { get; set; }

        public virtual TaskboardUser Processor { get; set; }

        public Status Status { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
