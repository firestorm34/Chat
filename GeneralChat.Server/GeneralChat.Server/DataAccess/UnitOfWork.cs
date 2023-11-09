using GeneralChat.Server.Models;
using GeneralChat.Server.Repositories;
namespace GeneralChat.Server.DataAccess
{
    public class UnitOfWork
    {
        public ChatContext context;
        public UnitOfWork(ChatContext dbContext)
        {
            context = dbContext;
        }
        private ChatRepository chatRepository;
        private MessageRepository messageRepository;
        private UserInGroupRepository userInGroupRepository;
        private RoleRepository roleRepository;
        private GroupRepository groupRepository;
        private UserRepository userRepository;
        private UnreadMessageRepository unreadMessageRepository;
        public ChatRepository ChatRepository { get => chatRepository == null ? new ChatRepository(context) : chatRepository; }
        public MessageRepository MessageRepository { get => messageRepository == null ? new MessageRepository(context) : messageRepository; }
        public UserInGroupRepository UserInGroupRepository { get => userInGroupRepository == null ? new UserInGroupRepository(context) : userInGroupRepository; }
        public RoleRepository RoleRepository { get => roleRepository == null ? new RoleRepository(context) : roleRepository; }
        public GroupRepository GroupRepository { get => groupRepository == null ? new GroupRepository(context) : groupRepository; }
        public UserRepository UserRepository { get => userRepository == null ? new UserRepository(context) : userRepository; }
        public UnreadMessageRepository UnreadMessageRepository { 
            get{ return unreadMessageRepository == null ? new UnreadMessageRepository(context) : unreadMessageRepository; }
        }
        public async Task SaveAsync()
        {
           await  context.SaveChangesAsync();
        }

        public void Save()
        {
            context.SaveChanges();
        }

    
    }
}
