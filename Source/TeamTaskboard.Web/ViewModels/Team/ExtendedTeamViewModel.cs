namespace TeamTaskboard.Web.ViewModels.Team
{
    using System.Collections.Generic;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Project;

    public class ExtendedTeamViewModel : TeamViewModel, ICustomMappings
    {
        public ExtendedTeamViewModel()
        {
            this.Members = new List<TeamMemberViewModel>();
            this.Projects = new List<ProjectViewModel>();
        }

        public virtual ICollection<TeamMemberViewModel> Members { get; set; }

        public virtual ICollection<ProjectViewModel> Projects { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //configuration.CreateMap<Team, ExtendedTeamViewModel>()
            //    .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));

            //configuration.CreateMap<Team, ExtendedTeamViewModel>()
            //    .ForMember(dest => dest.Members, opt => opt.MapFrom(src => src.Members));
        }
    }
}