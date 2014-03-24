using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;

namespace RecipiesWebFormApp
{
    public class RebindHub : Hub
    {
        public override System.Threading.Tasks.Task OnConnected()
        {
            return base.OnConnected();
        }

        public override System.Threading.Tasks.Task OnDisconnected()
        {
            return base.OnDisconnected();
        }

        public override Task OnReconnected()
        {
            return base.OnReconnected();
        }

        public void AddToGroup(string connectionId, string groupName)
        {
            Groups.Add(connectionId, groupName);
        }

        public void RebindRadGrid()
        {
            this.Clients.All.rebindRadGrid();
        }

        public void Hello()
        {
            Clients.All.hello();
        }
    }
}