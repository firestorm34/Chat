
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class ChatRepository : GenericRepository<Chat>
    {
        public ChatContext context;
        public ChatRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
    }
}
