namespace GeneralChat.Server.Models
{
    public class UserInGroup
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int GroupId { get; set; }
    }
}
