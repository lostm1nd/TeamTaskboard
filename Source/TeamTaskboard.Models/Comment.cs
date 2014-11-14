namespace TeamTaskboard.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [MinLength(5)]
        public string Content { get; set; }
    }
}
