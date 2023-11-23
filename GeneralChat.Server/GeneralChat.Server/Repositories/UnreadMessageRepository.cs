
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class UnreadMessageRepository 
    {
        public ChatContext context;
        public UnreadMessageRepository(ChatContext context) 
        {
            this.context = context;
        }
        /* ChatId just for convenince ,
        I indentify unreed message by its id and which user has/hasn't seen it*/
        public  async Task DeleteAsync(int userId, int messageId)
        {
            UnreadMessage? unreadMessage = await context.UnreadMessages.FirstOrDefaultAsync(m => m.UserId == userId &&  m.MessageId==messageId);
            if(unreadMessage == null)
            {

            }
            else {
                context.UnreadMessages.Remove(unreadMessage);
            }
        }

        public async Task AddAsync(int userId, int messageId)
        {
            await context.UnreadMessages.AddAsync(new UnreadMessage { UserId=userId, MessageId = messageId });
        }

        public async Task AddAsync(UnreadMessage unreadMessage)
        {
            await context.UnreadMessages.AddAsync(unreadMessage);
        }

    }
}
