namespace GeneralChat.Server.Models
{
    public class UserInGroup
    {

        [Required]
        public int UserId { get; set; }
        [Required]
        public int GroupId { get; set; }

        public virtual User User { get; set; } = new();

        public virtual Group Group { get; set; } = new();
    }
}
