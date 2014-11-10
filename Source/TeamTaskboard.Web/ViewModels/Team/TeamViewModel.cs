namespace TeamTaskboard.Web.ViewModels.Team
{
    using System.ComponentModel.DataAnnotations;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TeamViewModel : IMapFrom<Team>
    {
        public int TeamId { get; set; }

        public string Name { get; set; }
        
        [DisplayFormat(NullDisplayText = "No description provided.")]
        public string Description { get; set; }
    }
}