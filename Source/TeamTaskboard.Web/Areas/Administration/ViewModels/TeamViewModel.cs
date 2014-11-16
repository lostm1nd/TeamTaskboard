namespace TeamTaskboard.Web.Areas.Administration.ViewModels
{
    using System.Linq;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    public class TeamViewModel : IMapFrom<Team>, ICustomMappings
    {
        public int TeamId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MembersCount { get; set; }

        public int ProjectsCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(dest => dest.MembersCount, opt => opt.MapFrom(src => src.Members.Count()))
                .ForMember(dest => dest.ProjectsCount, opt => opt.MapFrom(src => src.Projects.Count()));
        }
    }
}