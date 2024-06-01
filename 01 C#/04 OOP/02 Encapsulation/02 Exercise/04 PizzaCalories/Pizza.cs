namespace Pizza
{
    public class Pizza
    {
        const int MinPizzaLenght = 1;
        const int MaxPizzaLenght = 15;
        const int MaxToppingCount = 10;

        List<Topping> toppings;

        private string name;

        public Pizza(string name)
        {
            Name = name;
            toppings = new List<Topping>();
        }

        public string Name
        {
            get => name; 
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < MinPizzaLenght || value.Length > MaxPizzaLenght)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }

        public Dough Dough { get; set; }

        public double Calories { get => toppings.Sum(x => x.Calories) + Dough.Calories; }

        public IReadOnlyCollection<Topping> Toppings
        {
            get => toppings;
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > MaxToppingCount)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            toppings.Add(topping);
        }
    }
}
