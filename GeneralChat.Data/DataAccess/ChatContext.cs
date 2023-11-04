global using Microsoft.EntityFrameworkCore;
global using GeneralChat.Data.Models;
namespace GeneralChat.Data.DataAccess
{
    public class ChatContext: DbContext
    {
        DbSet<User> Users;
        public ChatContext(DbContextOptions options): base(options)
        {

        }

    }
}
