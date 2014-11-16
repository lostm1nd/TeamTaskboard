namespace TeamTaskboard.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Avatar
    {
        [Key]
        public int AvatarId { get; set; }

        public byte[] Data { get; set; }

        public string ContentType { get; set; }
    }
}
