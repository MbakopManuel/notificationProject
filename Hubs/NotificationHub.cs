using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using Models;

namespace Hubs
{
    public interface INotificationHub
    {
        Task JoinNotification(string UserId);
        Task SendNotification(string UserId, Notification Notification);

    }

    public class NotificationHub : Hub, INotificationHub
    {

        private readonly IHubContext<NotificationHub> _context;
        public NotificationHub(IHubContext<NotificationHub> context){
            _context = context;
        }
        
        public Task JoinNotification(string ReferenceId)
            =>  _context.Groups.AddToGroupAsync(this.Context.ConnectionId, ReferenceId.ToString());
        public Task RemoveFromGroupNotification(string GroupId)
            => _context.Groups.RemoveFromGroupAsync(this.Context.ConnectionId, GroupId);
        public  Task SendNotification(string ReferenceId, Notification Notification)
            =>   _context.Clients.Group(ReferenceId).SendAsync("ReceiveNotification", Notification);

        public string GetConnectionId() => this.Context.ConnectionId;

    }
}