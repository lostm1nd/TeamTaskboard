namespace TeamTaskboard.Web.ViewModels.Team
{
    using System.Collections.Generic;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Project;

    public class ExtendedTeamViewModel : TeamViewModel
    {
        public ExtendedTeamViewModel()
        {
            this.Members = new List<TeamMemberViewModel>();
            this.Projects = new List<ProjectViewModel>();
        }

        public ICollection<TeamMemberViewModel> Members { get; set; }

        public ICollection<ProjectViewModel> Projects { get; set; }
    }
}