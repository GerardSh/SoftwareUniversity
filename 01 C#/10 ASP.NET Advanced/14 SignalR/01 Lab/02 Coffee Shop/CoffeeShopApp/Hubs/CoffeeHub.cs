using CoffeeShopApp.Models;
using CoffeeShopApp.Services.Contracts;
using Microsoft.AspNetCore.SignalR;

namespace CoffeeShopApp.Hubs
{
    public class CoffeeHub : Hub
    {
        private readonly IOrderService orderService;

        public CoffeeHub(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task GetUpdateForOrder(int orderId)
        {
            CheckResult result;

            do
            {
                result = orderService.GetUpdate(orderId);

                if (result.New)
                {
                    await Clients.Caller.SendAsync("ReceiveOrderUpdate", result.Update);
                }
            }
            while (!result.Finished);

            await Clients.Caller.SendAsync("Finished");
        }
    }
}
