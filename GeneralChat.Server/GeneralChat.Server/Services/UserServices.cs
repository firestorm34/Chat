using GeneralChat.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using GeneralChat.Server.ViewModels;
using GeneralChat.Server.Models;

namespace GeneralChat.Server.Services
{
    public class UserServices
    {
        private UnitOfWork unit;
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public UserServices(UnitOfWork unitOfWork, SignInManager<User> signInManager,
            UserManager<User> userManager)
        {
            unit = unitOfWork;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }


        public async Task<User> GetAsync(int id)
        {
            return await unit.UserRepository.GetAsync(id);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await unit.UserRepository.GetAllAsync();
        }

        public async Task Update(User user)
        {
            unit.UserRepository.Update(user);
            await unit.SaveAsync();
        }

        public async Task Delete( int id)
        {
            await unit.UserRepository.DeleteAsync(id);
        }



        public async Task<OperationResult> LoginAsync(LoginViewModel loginViewModel)
        {
            User user = await unit.UserRepository.GetByNicknameAsync(loginViewModel.Nickname);
            if (user==null)
            {
                return new OperationResult(OperationStatus.Failed, "User is not found");
            }

            var result = await signInManager.PasswordSignInAsync(loginViewModel.Nickname,
                loginViewModel.Password, loginViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return new OperationResult(OperationStatus.Successed);
            }
            else
            {
                return new OperationResult(OperationStatus.Failed, "Error! Can't successfull login!");
            }
          

        }

        public async Task LogOutAsync()
        {
           await signInManager.SignOutAsync();

        }

        public async Task<OperationResult> RegisterAsync(RegisterViewModel model)
        {
            User user = new User { Nickname = model.Nickname,
              UserName = model.Nickname  };
            var result = await userManager.CreateAsync(user, model.Password);
      
             if (result.Succeeded)
            {
                return new OperationResult(OperationStatus.Successed);
            }
            else
            {
                return new OperationResult(OperationStatus.Failed);
            }
        }
    }
}
