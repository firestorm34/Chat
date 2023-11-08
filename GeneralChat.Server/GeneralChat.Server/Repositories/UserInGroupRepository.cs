
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class UserInGroupRepository : GenericRepository<Chat>
    {
        public ChatContext context;
        public UserInGroupRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
    }
}
