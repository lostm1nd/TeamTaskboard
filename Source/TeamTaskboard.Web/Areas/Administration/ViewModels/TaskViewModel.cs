namespace TeamTaskboard.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class TaskViewModel : IMapFrom<TeamTask>, ICustomMappings
    {
        [Display(Name = "Id")]
        [HiddenInput(DisplayValue = false)]
        public int TeamTaskId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }

        [Display(Name = "Description")]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "Due Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yy at H:mm:ss}")]
        [HiddenInput(DisplayValue = false)]
        public DateTime DueDate { get; set; }

        [Display(Name = "Project Name")]
        [HiddenInput(DisplayValue = false)]
        public string ProjectName { get; set; }

        [Display(Name = "Reporter Name")]
        [HiddenInput(DisplayValue = false)]
        public string ReporterName { get; set; }

        [Display(Name = "Processor Name")]
        [HiddenInput(DisplayValue = false)]
        public string ProcessorName { get; set; }

        [HiddenInput(DisplayValue = false)]
        public string Status { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int CommentsCount { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<TeamTask, TaskViewModel>()
                .ForMember(dest => dest.ProjectName, opt => opt.MapFrom(src => src.Project.Name))
                .ForMember(dest => dest.ReporterName, opt => opt.MapFrom(src => src.Reporter.UserName))
                .ForMember(dest => dest.ProcessorName, opt => opt.MapFrom(src => src.Processor.UserName))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.CommentsCount, opt => opt.MapFrom(src => src.Comments.Count()))
                .ReverseMap();
        }
    }
}