using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Hubs
{
    public interface IChatHub
    {
        Task JoinConversation(int ConversationId);
        Task SendMessageToConversation(int ConversationId, string Sender, string message);
    }

    public class ChatHub : Hub, IChatHub
    {

        private readonly IHubContext<ChatHub> _context;
        public ChatHub(IHubContext<ChatHub> context){
            _context = context;
        }
        
        public Task JoinConversation(int ConversationId)
        {
            return _context.Groups.AddToGroupAsync(this.Context.ConnectionId, ConversationId.ToString());
        }

         public Task RemoveFromGroup(string GroupId)
            => _context.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, GroupId);

        public Task SendMessageToConversation(int ConversationId, string Sender, string message)
        {
            return _context.Clients.Group(ConversationId.ToString()).SendAsync("ReceiveMessage", Sender, message);
        }

        public string GetConnectionId() => Context.ConnectionId;

    }
}