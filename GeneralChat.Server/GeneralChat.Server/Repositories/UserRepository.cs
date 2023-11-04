
namespace GeneralChat.Server.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(DbContext _context) : base(_context)
        {
           
        }
    }
}
