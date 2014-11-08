namespace TeamTaskboard.Web.ViewModels
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class TeamViewModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<string> Statuses { get; set; }
    }
}