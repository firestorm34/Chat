

namespace GeneralChat.Server.Models
{
    public class Chat
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public int FirstUserId { get; set; }
        public int SecondUserId { get; set; }

        public virtual User User1 { get; set; } = new();
        public virtual User User2 { get; set; } = new();
    }
}
