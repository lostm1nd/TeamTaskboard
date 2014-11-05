namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Status
    {
        public Status()
        {
            this.Teams = new HashSet<Team>();
        }

        public int StatusId { get; set; }

        [Required]
        [Index(IsUnique=true)]
        [MinLength(3), MaxLength(25)]
        public string Name { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
