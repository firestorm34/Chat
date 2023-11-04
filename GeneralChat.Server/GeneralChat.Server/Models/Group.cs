
namespace GeneralChat.Server.Models
{
    public class Group
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public int CreatorId { get; set; }
        public string Name { get; set; }
        public DateTime CreationTime { get; set; }

    }
}
