global using Microsoft.EntityFrameworkCore;
global using GeneralChat.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GeneralChat.Server.DataAccess
{
    public class ChatContext: IdentityDbContext<User,Role, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserInGroup> UserInGroups { get; set; }
        public DbSet<Chat>  Chats { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<UnreadMessage> UnreadMessages { get; set; }
        public ChatContext()
        {

        }
        public ChatContext(DbContextOptions<ChatContext> options): base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ChatProject;" +
                    "Username=postgres;Password=Password12"
                );
            }
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserInGroup>(entity =>
            {
                entity.HasNoKey();
            }
            );
        }

    }
    //public class ChatContextFactory : IDesignTimeDbContextFactory<ChatContext>
    //{


    //    ChatContext IDesignTimeDbContextFactory<ChatContext>.CreateDbContext(string[] args)
    //    {
    //        var optionsBuilder = new DbContextOptionsBuilder<ChatContext>();
    //        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ChatProject;" +
    //        "Username=postgres;Password=Password12");

    //        return new ChatContext(optionsBuilder.Options);
    //    }
    //}
}
