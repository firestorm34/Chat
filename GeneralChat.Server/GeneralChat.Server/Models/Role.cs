using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace GeneralChat.Server.Models
{
    public class Role: IdentityRole<int>
    {
        public Role()
        {

        }
    }
}