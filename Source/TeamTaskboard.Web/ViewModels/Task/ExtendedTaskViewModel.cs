namespace TeamTaskboard.Web.ViewModels.Task
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Comment;
    using TeamTaskboard.Web.ViewModels.Status;

    public class ExtendedTaskViewModel : TaskViewModel, ICustomMappings
    {
        public ExtendedTaskViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

        [DisplayFormat(NullDisplayText = "No description provided.")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public StatusViewModel Status { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamTask, TaskViewModel>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TeamTaskId));
        }
    }
}