namespace TeamTaskboard.Web.InputModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class TaskInputModel
    {
        [Required]
        [MinLength(3), MaxLength(50)]
        public string Name { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Due Date")]
        public DateTime DueDate { get; set; }
    }
}