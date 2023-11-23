
using GeneralChat.Server.DataAccess;

namespace GeneralChat.Server.Repositories
{
    public class UserInGroupRepository  
    {
        public ChatContext context;
        public UserInGroupRepository(ChatContext context) 
        {
            this.context = context;
        }

        public async Task<UserInGroup?> GetAsync(int userId, int groupId)
        {
            return await context.UserInGroups.FirstOrDefaultAsync(u => u.UserId == userId 
                && u.GroupId == groupId);

        }
    
        public async Task<List<int>> GetUsersIdFromGroupAsync( int groupId)
        {
            List<int> userIds = await context.UserInGroups.Where(uig => uig.GroupId == groupId).Select(uig=>uig.UserId)
                .ToListAsync();
            return userIds;
        }
        public async Task<List<User>> GetUsersFromGroupAsync(int groupId)
        {
            List<User> users = await context.UserInGroups.Include(uig=>uig.User)
                .Where(uig => uig.GroupId == groupId).Select(uig=>uig.User).ToListAsync();
            return users;
        }
        
        public async Task DeleteAsync(int userId, int groupId)
        {
            UserInGroup? user = await GetAsync(userId, groupId);
            if (user != null)
            {
                context.UserInGroups.Remove(user);
            }
        }

        public async Task AddAsync(UserInGroup user)
        {
            if(GetAsync(user.UserId, user.GroupId) == null)
            {
                await context.UserInGroups.AddAsync(user);
            }
        }

    }
}
