namespace TeamTaskboard.Web.InputModels.Team
{
    using System.ComponentModel.DataAnnotations;

    public class TeamInputModel
    {

        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}