namespace TeamTaskboard.Web.ViewModels.Team
{
    using System.Collections.Generic;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TeamProjectViewModel : IMapFrom<Project>, ICustomMappings
    {
        public TeamProjectViewModel()
        {
            this.Tasks = new List<TeamTaskViewModel>();
        }
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TeamTaskViewModel> Tasks { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //configuration.CreateMap<Project, TeamProjectViewModel>()
            //    .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
        }
    }
}
