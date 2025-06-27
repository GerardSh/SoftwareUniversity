using CoffeeShopApp.Models;
using CoffeeShopApp.Services.Contracts;

namespace CoffeeShopApp.Services
{
    public class OrderService : IOrderService
    {
        private readonly Random random;
        private readonly IList<int> indexes;

        public OrderService(Random random, IList<int> indexes)
        {
            this.random = random;
            this.indexes = indexes;
        }

        private readonly string[] status =
        {
            "Grinding beans",
            "Steaming milk",
            "Quality control",
            "Delivering...",
            "Picked up"
        };

        public int NewOrder()
        {
            indexes.Add(0);
            return indexes.Count;
        }

        public CheckResult GetUpdate(int orderId)
        {
            Thread.Sleep(1000);
            var index = indexes[orderId - 1];

            if (random.Next(0, 4) == 2)
            {
                if (status.Length > indexes[orderId - 1])
                {
                    var result = new CheckResult()
                    {
                        New = true,
                        Update = status[index],
                        Finished = status.Length - 1 == index
                    };

                    indexes[orderId - 1]++;

                    return result;
                }
            }

            return new CheckResult { New = false };
        }
    }
}
