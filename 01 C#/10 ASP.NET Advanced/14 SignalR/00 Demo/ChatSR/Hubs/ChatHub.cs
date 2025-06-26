using ChatSR.Models;
using Microsoft.AspNetCore.SignalR;

using static ChatSR.Constants.MethodName;

namespace ChatSR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            MessageHistory.Messages.Add($"{user} says: {message}");

            await Clients.All.SendAsync(ReceiveMessage, user, message);
        }
    }
}
