using System.ComponentModel.DataAnnotations;
namespace TeamTaskboard.Web.ViewModels.Team
{
    public class TeamViewModel
    {
        public int TeamId { get; set; }

        public string Name { get; set; }
        
        [DisplayFormat(NullDisplayText = "No description provided.")]
        public string Description { get; set; }
    }
}