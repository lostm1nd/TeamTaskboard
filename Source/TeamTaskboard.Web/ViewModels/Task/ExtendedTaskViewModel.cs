namespace TeamTaskboard.Web.ViewModels.Task
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;
    using TeamTaskboard.Web.ViewModels.Comment;

    public class ExtendedTaskViewModel : TaskViewModel
    {
        public ExtendedTaskViewModel()
        {
            this.Comments = new List<CommentViewModel>();
        }

        [DisplayFormat(NullDisplayText = "No description provided.")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public string Reporter { get; set; }

        [DisplayFormat(NullDisplayText = "There is no processor for this task.")]
        public string Processor { get; set; }

        public Status Status { get; set; }

        public ICollection<CommentViewModel> Comments { get; set; }

        public override void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamTask, ExtendedTaskViewModel>()
                .ForMember(dest => dest.TaskId, opt => opt.MapFrom(src => src.TeamTaskId))
                .ForMember(dest => dest.Reporter, opt => opt.MapFrom(src => src.Reporter.UserName))
                .ForMember(dest => dest.Processor, opt => opt.MapFrom(src => src.Processor.UserName));
        }
    }
}