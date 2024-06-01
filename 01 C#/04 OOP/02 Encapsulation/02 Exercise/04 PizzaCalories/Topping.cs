namespace Pizza
{
    public class Topping
    {
        const double MinToppingWeight = 1;
        const double MaxToppingWeight = 50;

        private string type;
        private double weight;
        private double calories;

        public Topping(string type, double weight)
        {
            Type = type;
            Weight = weight;

            SetCalories();
        }

        string Type
        {
            get => type;
            set
            {
                string valueInLowerCap = value.ToLower();

                if (valueInLowerCap != "meat" && valueInLowerCap != "veggies" && valueInLowerCap != "cheese" && valueInLowerCap != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                type = value;
            }
        }
        double Weight
        {
            get => weight;
            set
            {
                if (value < MinToppingWeight || value > MaxToppingWeight)
                {
                    throw new ArgumentException($"{Type} weight should be in the range [1..50].");
                }

                weight = value;
            }
        }

        public double Calories
        {
            get => calories;
            private set
            {
                calories = value;
            }
        }

        private void SetCalories()
        {
            double modifier = 0;
            string type = Type.ToLower();

            if (type.ToLower() == "meat")
            {
                modifier = 1.2;
            }
            else if (type.ToLower() == "veggies")
            {
                modifier = 0.8;
            }
            else if (type.ToLower() == "cheese")
            {
                modifier = 1.1;
            }
            else
            {
                modifier = 0.9;
            }

            Calories = Weight * 2 * modifier;
        }
    }
}
