global using Microsoft.AspNetCore.Identity;
global using System.ComponentModel.DataAnnotations;

namespace GeneralChat.Server.Models
{
    public class User : IdentityUser<int>
    {
        [Required]

        public string Nickname { get; set; }

        public DateTime LastSeen { get; set; }
        public bool IsOnline { get; set; }

        public HashSet<Chat> Chats { get; set; } = new();
        public HashSet<Message> Messages { get; set; } = new();
        public HashSet<Group> Groups { get; set; } = new HashSet<Group>();
        public HashSet<Contact> Contacts { get; set; } = new HashSet<Contact>();
        public HashSet<UnreadMessage> UnreadMessages { get; set; } = new();

    }
}
