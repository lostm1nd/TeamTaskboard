namespace TeamTaskboard.Web.InputModels.Project
{
    using System.ComponentModel.DataAnnotations;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class ProjectInputModel : IMapFrom<Project>
    {
        [Display(Name = "Id")]
        public int? ProjectId { get; set; }

        [Display(Name = "Project Name")]
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Project Description")]
        public string Description { get; set; }
    }
}