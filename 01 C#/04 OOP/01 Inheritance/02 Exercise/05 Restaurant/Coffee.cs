namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        const decimal CoffeePrice = 3.5m;
        const double CoffeeMilliliters = 50;

        public Coffee(string name, double caffeine)
           : base(name, CoffeePrice, CoffeeMilliliters)
        {
            Caffeine = caffeine;
        }

       public double Caffeine { get; set; }
    }
}
