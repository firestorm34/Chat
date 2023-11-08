
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class MessageRepository : GenericRepository<Message>
    {
        public ChatContext context;
        public MessageRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
    }
}
