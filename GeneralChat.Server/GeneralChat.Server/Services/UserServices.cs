using GeneralChat.Server.DataAccess;
using Microsoft.EntityFrameworkCore;
using GeneralChat.Server.ViewModels;
using GeneralChat.Server.Models;
using Microsoft.AspNetCore.Mvc;

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



        public async Task<User?> GetAsync(int id)
        {
            return await unit.UserRepository.GetAsync(id);
        }
        public async Task<List<User>> GetAllAsync()
        {
            return await unit.UserRepository.GetAllAsync();
        }

        public async Task UpdateAsync(User user)
        {
            unit.UserRepository.Update(user);
            await unit.SaveAsync();
        }

        public async Task DeleteAsync( int id)
        {
            await unit.UserRepository.DeleteAsync(id);
            await unit.SaveAsync();
        }


        public async Task<bool> GetOnlineStatusAsync(int userId)
        {
            var user = await unit.UserRepository.GetAsync(userId);
            return user.IsOnline;
        }

        public async Task GoOfflineAsync(int userId)
        {
            var user = await unit.UserRepository.GetAsync(userId);
            user.IsOnline = false;
            user.LastSeen = DateTime.Now;
            unit.UserRepository.Update(user);
            await unit.SaveAsync();
        }

        public async Task<OperationResult> GoOnlineAsync(int userId)
        {
            var user = await unit.UserRepository.GetAsync(userId);
            if(user != null) { 
                user.IsOnline = true;
                unit.UserRepository.Update(user);
                await unit.SaveAsync();
                return new OperationResult(OperationStatus.Successed);
            }
            return new OperationResult(OperationStatus.Failed, new Exception("User is not found!"));
        }

        // GROUP ASSOSIATED ACTIONS
        public async Task<OperationResult> JoinGroupAsync(int userId, int groupId)
        {
            User? user = await unit.UserRepository.GetAsync(userId);
            Group? group = await unit.GroupRepository.GetAsync(groupId);
            if(user != null) { 
                if(group !=null)
                {
                    await unit.UserInGroupRepository.AddAsync(new UserInGroup { UserId = userId, GroupId = groupId });
                    await unit.SaveAsync();
                    return new OperationResult(OperationStatus.Successed);
                }
                return new OperationResult(OperationStatus.Failed, new Exception($"Group with id: {groupId} is not found in database "));
            }
            return new OperationResult(OperationStatus.Failed, new Exception($"User with id: {userId} is not found in database"));
        }

        public async Task<OperationResult> LeftGroupAsync(int userId, int groupId)
        {
            User? user = await unit.UserRepository.GetAsync(userId);
            Group? group = await unit.GroupRepository.GetAsync(groupId);
            if (user != null)
            {
                if (group != null)
                {
                    UserInGroup? userInGroup = await unit.UserInGroupRepository.GetAsync(userId, groupId);
                    if(userInGroup != null)
                    {
                        await unit.UserInGroupRepository.DeleteAsync( userId, groupId);
                        await unit.SaveAsync();
                        return new OperationResult(OperationStatus.Successed);
                    }

                    return new OperationResult(OperationStatus.Failed, new Exception("Yikes! Current User is not in this Group"));
                }
                return new OperationResult(OperationStatus.Failed, new Exception($"Group with id: {groupId} is not found in database "));
            }
            return new OperationResult(OperationStatus.Failed, new Exception($"User with id: {userId} is not found in database"));
        }

        // ACCOUNT ACTIONS
        public async Task<OperationResult> LoginAsync(LoginViewModel loginViewModel)
        {
            User user = await unit.UserRepository.GetByNicknameAsync(loginViewModel.Nickname);
            if (user==null)
            {
                return new OperationResult(OperationStatus.Failed, new Exception( "User is not found"));
            }

            var result = await signInManager.PasswordSignInAsync(loginViewModel.Nickname,
                loginViewModel.Password, loginViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                return new OperationResult(OperationStatus.Successed);
            }
            else
            {
                return new OperationResult(OperationStatus.Failed,new Exception( "Error! Can't successfull login!"));
            }
          

        }

        //public async Task<List<User>> GetUsersForChat(int chatId)
        //{
        //    List<User> users = unit.UserRepository.
        //}
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
