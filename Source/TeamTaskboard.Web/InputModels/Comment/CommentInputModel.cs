namespace TeamTaskboard.Web.InputModels.Comment
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    using TeamTaskboard.Models;
    using TeamTaskboard.Web.Infrastructure.Mappings;

    public class CommentInputModel : IMapFrom<Comment>
    {
        public int? CommentId { get; set; }

        [Required]
        [AllowHtml]
        [MinLength(5)]
        [UIHint("TinyMCE")]
        public string Content { get; set; }

        public int TaskId { get; set; }
    }
}