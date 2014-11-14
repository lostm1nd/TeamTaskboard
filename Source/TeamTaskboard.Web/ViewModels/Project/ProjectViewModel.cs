namespace TeamTaskboard.Web.ViewModels.Project
{
    using System.Collections.Generic;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Task;

    public class ProjectViewModel : IMapFrom<Project>, ICustomMappings
    {
        public ProjectViewModel()
        {
            this.Tasks = new List<TaskViewModel>();
        }

        public int ProjectId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<TaskViewModel> Tasks { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            //configuration.CreateMap<Project, TeamProjectViewModel>()
            //    .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks))
        }
    }
}
