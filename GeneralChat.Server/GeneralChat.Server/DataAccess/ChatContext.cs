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
            modelBuilder.Entity<UserInGroup>().HasKey(nameof(UserInGroup.UserId),nameof(UserInGroup.GroupId));
            // To create complicated key with 2+ fields as key 
            modelBuilder.Entity<UnreadMessage>().HasKey(nameof(UnreadMessage.MessageId), nameof(UnreadMessage.UserId));
            modelBuilder.Entity<Contact>(entity =>
            {
                entity.HasOne(e => e.Owner).WithMany(u => u.Contacts).HasForeignKey(e => e.OwnerId);
                entity.HasOne(e => e.ContactUser).WithMany().HasForeignKey(e => e.ContactId);
            });
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasOne(e => e.User1).WithMany(u => u.Chats).HasForeignKey(e => e.FirstUserId);
                entity.HasOne(e => e.User2).WithMany().HasForeignKey(e => e.SecondUserId);
            });
            modelBuilder.Entity<UserInGroup>(entity =>
            {
                entity.HasOne(e => e.Group).WithMany(g => g.UsersInGroup).HasForeignKey(e => e.GroupId);
            });
        }

    }
    // It allows us to create template <T> for our dbContext

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
