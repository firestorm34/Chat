using GeneralChat.Server.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace GeneralChat.Server.Services
{
    public class UserServices
    {
        private UnitOfWork unit;
        public UserServices(UnitOfWork unitOfWork)
        {
            unit = unitOfWork;
        }
        public void Login()
        {

        }
        public void Register()
        {

        }
    }
}
