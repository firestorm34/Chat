using Microsoft.AspNetCore.SignalR;

namespace GeneralChat.Server
{
    public class UserHub: Hub
    {
        public async Task SendMessage(string message)
        {

            await Clients.Client(Context.ConnectionId).SendAsync("ReceiveMessage", message.ToString());



        }

        public async Task SendUser(User user)
        {

            await Clients.Caller.SendAsync("ReceiveUser", user);
        }
    }
}
