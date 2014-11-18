namespace TeamTaskboard.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class ProjectViewModel : IMapFrom<Project>, ICustomMappings
    {
        [Display(Name = "Id")]
        [HiddenInput(DisplayValue = false)]
        public int ProjectId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Team Name")]
        [HiddenInput(DisplayValue = false)]
        public string TeamName { get; set; }

        [Display(Name = "Tasks Count")]
        [HiddenInput(DisplayValue = false)]
        public int TasksCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Project, ProjectViewModel>()
                .ForMember(dest => dest.TeamName, opt => opt.MapFrom(src => src.Team.Name))
                .ForMember(dest => dest.TasksCount, opt => opt.MapFrom(src => src.Tasks.Count()))
                .ReverseMap();
        }
    }
}