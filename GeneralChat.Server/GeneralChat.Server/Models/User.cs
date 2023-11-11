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

    }
}
