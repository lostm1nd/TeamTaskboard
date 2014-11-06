namespace TeamTaskboard.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TeamTask
    {
        public int TeamTaskId { get; set; }

        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int TeamId { get; set; }

        public virtual Team Team { get; set; }

        public virtual User Reporter { get; set; }

        public virtual User Processor { get; set; }

        [Required]
        public int StatusId { get; set; }

        public Status Status { get; set; }
    }
}
