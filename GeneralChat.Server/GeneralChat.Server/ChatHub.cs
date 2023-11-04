using Microsoft.AspNetCore.SignalR;
using GeneralChat.Server.Services;
using GeneralChat;

namespace GeneralChat.Server
{
    public class ChatHub : Hub
    {
        private UserServices userServices;
        public ChatHub(UserServices userServ)
        {
            userServices = userServ;
        }

        public async Task Login(string nickname, string password)
        {

        }

        public async Task Register(string nickname, string password)
        {

        }

        public async Task SendMessage( string message)
        {

            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", message.ToString());
 
        }



        public async Task SendUser(User user)
        {
            
            await Clients.Caller.SendAsync("ReceiveUser", user);
        }

        //public override async Task OnConnectedAsync()
        //{

        //    //await Clients.AllExcept(new List<string>() { $"{this.Context.ConnectionId}" })
        //    //    .SendAsync("ReceiveUserConnectedNotification", $"{Context.ConnectionId} вошел в чат");

        //    await base.OnConnectedAsync();
        //}
        //public override async Task OnDisconnectedAsync(Exception? exception)
        //{
        //    //await Clients.AllExcept(new List<string>() { $"{this.Context.ConnectionId}" })
        //    //    .SendAsync("ReceiveUserDisconnectedNotification", $"{Context.ConnectionId} покинул  чат");

        //    await base.OnDisconnectedAsync(exception);
        //}

    }



    
}





//public async Task SendStringList(List<string> items)
//{
//    await Clients.Client(Context.ConnectionId).SendAsync("Notify", "Ваше сообщение отправлено");
//    await Clients.Caller.SendAsync("ReceiveStringList", items);
//    await Clients.AllExcept(Context.ConnectionId).SendAsync("ReceiveStringList", items);

//}


//public async Task AddProduct(Product? product)
//{
//    await Clients.Client(Context.ConnectionId).SendAsync("NotifyInfoAboutProduct", "Ваш товар добавлен");
//    await Clients.All.SendAsync("ReceiveProduct", "Добавлен продукт " + product?.Name.ToString() + " !");
//    Product P2 = product;
//    int a = 1;
//}