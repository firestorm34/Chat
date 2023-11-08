
using GeneralChat.Server.DataAccess;
using System.Security.Cryptography.X509Certificates;

namespace GeneralChat.Server.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public ChatContext context;
        public UserRepository(ChatContext context) : base(context)
        {
            this.context = context;
        }
        public async Task<User> GetByNicknameAsync(string nickname)
        {
            return await context.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }



    }
}
