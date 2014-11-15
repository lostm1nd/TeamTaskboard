namespace TeamTaskboard.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [MinLength(5)]
        public string Content { get; set; }

        [Required]
        public string PostedBy { get; set; }

        [Required]
        public DateTime PostedOn { get; set; }

        [Required]
        public int TeamTaskId { get; set; }

        public virtual TeamTask TeamTask { get; set; }
    }
}
