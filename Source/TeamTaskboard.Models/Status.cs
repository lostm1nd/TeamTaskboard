namespace TeamTaskboard.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public enum Status
    {
        NotStarted,
        InProgress,
        InReview,
        Blocked,
        Done
    }
}
