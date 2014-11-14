namespace TeamTaskboard.Web.ViewModels.Comment
{
    using System;
    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class CommentViewModel : IMapFrom<Comment>
    {
        public int CommentId { get; set; }

        public string Content { get; set; }

        public string PostedBy { get; set; }

        public DateTime PostedOn { get; set; }
    }
}