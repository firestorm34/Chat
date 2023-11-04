global using GeneralChat.Data.Models;
global using Microsoft.EntityFrameworkCore;

namespace GeneralChat.Services
{
    public class UserService
    {
        private DbContext context;
        public UserService(DbContext context)
        {
            this.context = context;
        }
    }
}
