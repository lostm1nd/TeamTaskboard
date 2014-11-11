namespace TeamTaskboard.Web.ViewModels.Team
{
    using AutoMapper;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TeamMemberViewModel : IMapFrom<TaskboardUser>, ICustomMappings
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int ReportedTasksCount { get; set; }

        public int ProcessedTasksCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TaskboardUser, TeamMemberViewModel>()
                .ForMember(dest => dest.ProcessedTasksCount, opt => opt.MapFrom(src => src.ProcessedTasks.Count));

            configuration.CreateMap<TaskboardUser, TeamMemberViewModel>()
                .ForMember(dest => dest.ReportedTasksCount, opt => opt.MapFrom(src => src.ReportertedTasks.Count));
        }
    }
}
