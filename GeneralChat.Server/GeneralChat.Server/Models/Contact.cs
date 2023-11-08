namespace GeneralChat.Server.Models
{
    public class Contact
    {
        [Key]
        public int OwnerId { get; set; }
        public int ContactId { get; set; }
    }
}
