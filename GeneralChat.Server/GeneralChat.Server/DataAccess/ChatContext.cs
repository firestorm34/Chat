global using Microsoft.EntityFrameworkCore;
global using GeneralChat.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace GeneralChat.Server.DataAccess
{
    public class ChatContext: IdentityDbContext<User,Role, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInGroup> UserInGroups { get; set; }
        public DbSet<Chat>  Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public ChatContext(DbContextOptions options): base(options)
        {

        }

    }
}
