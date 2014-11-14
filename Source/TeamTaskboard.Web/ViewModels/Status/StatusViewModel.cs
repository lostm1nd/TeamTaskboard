namespace TeamTaskboard.Web.ViewModels.Status
{
    using System.ComponentModel.DataAnnotations;

    public enum StatusViewModel
    {
        [Display(Name = "Not started")]
        NotStarted,

        [Display(Name = "In progreess")]
        InProgress,

        [Display(Name = "In review")]
        InReview,

        [Display(Name = "Blocked")]
        Blocked,

        [Display(Name = "Done")]
        Done
    }
}