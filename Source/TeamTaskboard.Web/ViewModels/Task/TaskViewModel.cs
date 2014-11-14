namespace TeamTaskboard.Web.ViewModels.Task
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Status;

    public class TaskViewModel : IMapFrom<TeamTask>, ICustomMappings
    {
        public int TaskId { get; set; }

        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        [DisplayFormat(NullDisplayText = "No description provided.")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public StatusViewModel Status { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamTask, TaskViewModel>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TeamTaskId));
        }
    }
}