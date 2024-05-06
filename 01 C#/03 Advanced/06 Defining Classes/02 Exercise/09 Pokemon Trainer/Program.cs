namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var trainers = new Dictionary<string, Trainer>();

            int trainerCount = 0;
            string input;

            while ((input = Console.ReadLine()) != "Tournament")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string trainerName = elements[0];
                string pokemonName = elements[1];
                string pokemonElement = elements[2];
                int pokemonHealth = int.Parse(elements[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers.Add(trainerName, new Trainer());
                    trainers[trainerName].Order = trainerCount++;
                }

                var pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                trainers[trainerName].Pokemons.Add(pokemon);
            }

            string element;

            while ((element = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Where(x => x.Value.Pokemons.Any(p => p.Element == element)))
                {
                    trainer.Value.NumberOfBadges++;
                }

                foreach (var trainer in trainers.Where(x => !x.Value.Pokemons.Any(p => p.Element == element)))
                {
                    foreach (var pokemon in trainer.Value.Pokemons)
                    {
                        pokemon.Health -= 10;
                    }

                    trainer.Value.Pokemons.RemoveAll(x => x.Health < 1);
                }
            }

            trainers = trainers.OrderByDescending(x => x.Value.NumberOfBadges)
                .ThenBy(x => x.Value.Order)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var kvp in trainers)
            {
                Console.Write($"{kvp.Key} {kvp.Value.NumberOfBadges} {kvp.Value.Pokemons.Count}");
                Console.WriteLine();
            }
        }
    }
}