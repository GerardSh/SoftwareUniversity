using CoffeeShopApp.Models;

namespace CoffeeShopApp.Services.Contracts
{
    public interface IOrderService
    {
        int NewOrder();

        CheckResult GetUpdate(int orderId);
    }
}
