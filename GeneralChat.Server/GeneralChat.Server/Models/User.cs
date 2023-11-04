global using Microsoft.AspNetCore.Identity;
global using System.ComponentModel.DataAnnotations;

namespace GeneralChat.Server.Models
{
    public class User : IdentityUser<int>
    {
        [Required]

        public string? Nickname { get; set; }



    }
}
