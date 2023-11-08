
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        public ChatContext context;
        public RoleRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
    }
}
