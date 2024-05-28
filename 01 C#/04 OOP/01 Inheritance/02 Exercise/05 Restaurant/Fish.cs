namespace Restaurant
{
    public class Fish : MainDish
    {
        const double FishGrams = 22;

        public Fish(string name, decimal price)
            : base(name, price, FishGrams)
        {

        }
    }
}
