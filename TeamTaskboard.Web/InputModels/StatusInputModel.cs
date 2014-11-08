namespace TeamTaskboard.Web.InputModels
{
    using System.ComponentModel.DataAnnotations;

    public class StatusInputModel
    {
        [Required]
        [MinLength(3), MaxLength(25)]
        public string Name { get; set; }
    }
}