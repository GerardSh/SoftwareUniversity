namespace Pizza
{
    public class Dough
    {
        const double MinDoughWeight = 1;
        const double MaxDoughWeight = 200;

        string flourType;
        string bakingTechnique;
        double weight;
        double calories;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weight = weight;

            SetCalories();
        }

        string FlourType
        {
            get => flourType;
            set
            {
                string valueInLowerCap = value.ToLower();

                if (valueInLowerCap != "white" && valueInLowerCap != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                flourType = value;
            }
        }

        string BakingTechnique
        {
            get => bakingTechnique;
            set
            {
                string valueInLowerCap = value.ToLower();

                if (valueInLowerCap != "crispy" && valueInLowerCap != "chewy" && valueInLowerCap != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                bakingTechnique = value;
            }
        }

        double Weight
        {
            get => weight;
            set
            {
                if (value < MinDoughWeight || value > MaxDoughWeight)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
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

        void SetCalories()
        {
            double typeModifier = 0;
            double techniqueModifier = 0;

            if (FlourType.ToLower() == "white")
            {
                typeModifier = 1.5;
            }
            else
            {
                typeModifier = 1.0;
            }

            if (BakingTechnique.ToLower() == "crispy")
            {
                techniqueModifier = 0.9;
            }
            else if (BakingTechnique.ToLower() == "chewy")
            {
                techniqueModifier = 1.1;
            }
            else
            {
                techniqueModifier = 1.0;
            }

            Calories = Weight * 2 * typeModifier * techniqueModifier;
        }
    }
}
