namespace ConsoleApp
{
    public class Trainer
    {
        public string Name { get; set; }

        public int NumberOfBadges { get; set; }

        public int Order { get; set; }

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();

    }
}