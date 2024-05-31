namespace ConsoleApp1
{
    public class Product
    {
        private string name;
        private decimal cost;

        public Product(string name, decimal cost)
        {
            Name = name;
            Cost = cost;
        }

        public string Name
        {
            get => name;
            private set
            {
                Program.IsNameValid(value);
                name = value;
            }
        }

        public decimal Cost
        {
            get => cost;
            private set
            {
                Program.IsMoneyValid(value);
                cost = value;
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
