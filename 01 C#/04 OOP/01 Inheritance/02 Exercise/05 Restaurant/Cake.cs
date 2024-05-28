namespace Restaurant
{
    public class Cake : Dessert
    {
        const decimal CakePrice = 5m;
        const double CakeGrams = 250;
        const double CakeCalories = 1000;

        public Cake(string name)
            :base(name, CakePrice, CakeGrams, CakeCalories)
        {

        }
    }
}
