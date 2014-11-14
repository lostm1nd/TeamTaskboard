namespace TeamTaskboard.Web.ViewModels.Task
{
    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TaskViewModel : IMapFrom<TeamTask>, ICustomMappings
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        public virtual void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamTask, TaskViewModel>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TeamTaskId));
        }
    }
}