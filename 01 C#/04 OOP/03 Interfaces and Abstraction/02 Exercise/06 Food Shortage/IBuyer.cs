namespace FoodShortage
{
    public interface IBuyer
    {
        string Name { get; set; }

        int Food { get; set; }

        void BuyFood();
    }
}
