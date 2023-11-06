using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GeneralChat.Server.Models
{
    public class Message
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime SentTime { get; set; }
        public int UserId { get; set; }
        public int ChatId { get; set; }
        public bool IsViewed { get; set; }

        public virtual User User { get; set; } = new ();
        public virtual Chat Chat { get; set; } = new ();
    }
}
