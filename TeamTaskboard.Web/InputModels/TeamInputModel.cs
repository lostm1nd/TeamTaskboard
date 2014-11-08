namespace TeamTaskboard.Web.InputModels
{

    using System.ComponentModel.DataAnnotations;

    public class TeamInputModel
    {
        [Required]
        [MinLength(3), MaxLength(30)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [MaxLength(100)]
        public string Description { get; set; }
    }
}