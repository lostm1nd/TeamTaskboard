namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Status
    {
        [Display(Name = "Not Started")]
        NotStarted,

        [Display(Name = "In Progress")]
        InProgress,

        [Display(Name = "In Review")]
        InReview,

        [Display(Name = "Blocked")]
        Blocked,

        [Display(Name = "Done")]
        Done
    }
}
