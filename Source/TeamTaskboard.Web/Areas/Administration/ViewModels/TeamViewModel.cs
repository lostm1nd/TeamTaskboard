namespace TeamTaskboard.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    public class TeamViewModel : IMapFrom<Team>, ICustomMappings
    {
        [Display(Name="Id")]
        public int TeamId { get; set; }

        [Display(Name="Team Name")]
        public string Name { get; set; }

        [Display(Name="Team Description")]
        [DisplayFormat(NullDisplayText="No description provided.")]
        public string Description { get; set; }

        [Display(Name = "Members Count")]
        public int MembersCount { get; set; }

        [Display(Name = "Projects Count")]
        public int ProjectsCount { get; set; }

        public void CreateMappings(AutoMapper.IConfiguration configuration)
        {
            configuration.CreateMap<Team, TeamViewModel>()
                .ForMember(dest => dest.MembersCount, opt => opt.MapFrom(src => src.Members.Count()))
                .ForMember(dest => dest.ProjectsCount, opt => opt.MapFrom(src => src.Projects.Count()));
        }
    }
}