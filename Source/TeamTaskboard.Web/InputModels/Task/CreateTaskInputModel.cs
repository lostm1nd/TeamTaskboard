namespace TeamTaskboard.Web.InputModels.Task
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class CreateTaskInputModel : IMapFrom<TeamTask>
    {
        [Display(Name = "Id")]
        public int? TeamTaskId { get; set; }
        
        [Required]
        [MinLength(3), MaxLength(50)]
        [Display(Name = "Task Name")]
        public string Name { get; set; }        
        
        [DataType(DataType.MultilineText)]
        [Display(Name = "Task Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }

        [Required]
        [EnumDataType(typeof(Status))]
        [Display(Name = "Task Status")]
        public Status Status { get; set; }

        [Display(Name = "Related Project")]
        public int ProjectId { get; set; }
    }
}