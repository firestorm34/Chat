
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class GroupRepository : GenericRepository<Group>
    {
        public ChatContext context;
        public GroupRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }


    }
}
