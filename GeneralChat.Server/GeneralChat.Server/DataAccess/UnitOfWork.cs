using GeneralChat.Server.Models;
using GeneralChat.Server.Repositories;
namespace GeneralChat.Server.DataAccess
{
    public class UnitOfWork
    {
        private DbContext context;
        public UnitOfWork(DbContext dbContext)
        {
            context = dbContext;
        }
        private UserRepository userRepository;
        public UserRepository UserRepository { get => userRepository == null ? new UserRepository(context) : userRepository; }
    }
}
