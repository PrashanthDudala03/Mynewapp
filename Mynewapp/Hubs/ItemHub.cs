using Microsoft.AspNetCore.SignalR;
using Mynewapp.Models;
using System.Threading.Tasks;

namespace Mynewapp.Hubs
{
    public class ItemHub : Hub
    {
        public async Task SendItemUpdate(Item item)
        {
            await Clients.All.SendAsync("ReceiveItemUpdate", item);
        }

        public async Task SendItemCreated(Item item)
        {
            await Clients.All.SendAsync("ReceiveItemCreated", item);
        }

        public async Task SendItemDeleted(int itemId)
        {
            await Clients.All.SendAsync("ReceiveItemDeleted", itemId);
        }

        public async Task SendNotification(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveNotification", user, message);
        }
    }
}
