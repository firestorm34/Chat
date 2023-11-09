
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class UnreadMessageRepository : GenericRepository<UnreadMessage>
    {
        public ChatContext context;
        public UnreadMessageRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
        public new async Task DeleteAsync(int id)
        {

        }
        public new async Task DeleteAsync(int userId, int messageId)
        {
            UnreadMessage? unreadMessage = await context.UnreadMessages.FirstOrDefaultAsync(m => m.UserId == userId &&  m.MessageId==messageId);
            if(unreadMessage == null)
            {

            }
            else {
                context.UnreadMessages.Remove(unreadMessage);
            }
        }

    }
}
