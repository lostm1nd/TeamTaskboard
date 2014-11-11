namespace TeamTaskboard.Web.ViewModels.Team
{
    using System;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TeamTaskViewModel : IMapFrom<TeamTask>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTime DueDate { get; set; }

        public string Status { get; set; }
    }
}