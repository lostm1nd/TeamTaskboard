namespace TeamTaskboard.Web.Models
{
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;

    using TeamTaskboard.Models;

    public class TeamViewModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<string> Statuses { get; set; }
    }
}