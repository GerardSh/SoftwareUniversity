using CoffeeShopApp.Hubs;
using CoffeeShopApp.Models;
using CoffeeShopApp.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

[ApiController]
[Route("[controller]")]
public class CoffeeController : Controller
{
    IOrderService orderService;
    IHubContext<CoffeeHub> coffeeHub;

    public CoffeeController(IOrderService orderService, IHubContext<CoffeeHub> coffeeHub)
    {
        this.orderService = orderService;
        this.coffeeHub = coffeeHub;
    }

    [HttpPost]
    public async Task<IActionResult> OrderCoffee([FromBody] Order order)
    {
        await coffeeHub.Clients.All.SendAsync("NewOrder", order);
        var orderId = orderService.NewOrder();

        return Accepted(orderId);
    }
}