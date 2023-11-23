global using Microsoft.AspNetCore.Identity;
global using System.ComponentModel.DataAnnotations;

namespace GeneralChat.Server.Models
{
    public class UnreadMessage
    {
        [Required]
        public int UserId { get; set; }
        public int MessageId { get; set; }
        public int ChatId { get; set; }

        public virtual User User { get; set; } = new();
        public virtual Message Message { get; set; } = new();
        public virtual Chat Chat { get; set; } = new();
    }
}
