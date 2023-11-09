
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

        public async Task<List<Message>> GetByChatId(int id)
        {
            return await context.Messages.Where(m => m.ChatId == id).ToListAsync();
        }
        public async Task<List<Message>> GetBatchByChatId(int id, int batch_size)
        {
            return  await context.Messages.Where(m => m.ChatId == id).Take(batch_size).ToListAsync();
        }

    }
}
