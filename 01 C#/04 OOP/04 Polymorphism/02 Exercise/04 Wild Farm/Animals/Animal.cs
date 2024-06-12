namespace WildFarm
{
    public abstract class Animal
    {
        private double weight;

        Dictionary<string, double> weightMap = new Dictionary<string, double>()
        {
            {"Hen", 0.35},
            {"Owl", 0.25},
            {"Mouse", 0.10},
            {"Cat", 0.30},
            {"Dog", 0.40},
            {"Tiger", 1}
        };

        protected Animal(string name, double weight)
        {
            Name = name;
            this.weight = weight;
        }

        public string Name { get; set; }

        public virtual double Weight
        {
            get => weight;
            set
            {
                weight += weightMap[GetType().Name] * value;
            }
        }

        public int FoodEaten { get; set; }

        public abstract string ProduceSound();

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}";
        }
    }
}
