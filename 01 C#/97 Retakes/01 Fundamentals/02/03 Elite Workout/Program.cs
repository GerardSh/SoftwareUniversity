class Exercise
{
    public Exercise(string name, string group, int difficultyLevel)
    {
        Name = name;
        Group = group;
        DifficultyLevel = difficultyLevel;
    }

    public string Name { get; set; }

    public string Group { get; set; }

    public int DifficultyLevel { get; set; }
}

class Program
{
    public static void Main()
    {
        string input;

        var exercises = new List<Exercise>();

        while ((input = Console.ReadLine()) != "Stay Hard!")
        {
            var elements = input.Split(": ", StringSplitOptions.RemoveEmptyEntries);
            var command = elements[0];
            var commandElements = elements[1].Split("#");

            if (command == "Exercise")
            {
                var name = commandElements[0];
                var group = commandElements[1];
                var difficultyLevel = int.Parse(commandElements[2]);

                var currentExercise = exercises.FirstOrDefault(x => x.Name == name);

                if (currentExercise != null)
                {
                    Console.WriteLine($"Exercise {name} is already in the training plan");
                    continue;
                }

                currentExercise = new Exercise(name, group, difficultyLevel);

                exercises.Add(currentExercise);
            }
            else if (command == "Weight Vest")
            {
                var name = commandElements[0];
                var weight = int.Parse(commandElements[1]);

                var currentExercise = exercises.FirstOrDefault(x => x.Name == name);

                if (currentExercise == null)
                {
                    Console.WriteLine($"Exercise {name} is not in the training plan");
                    continue;
                }

                currentExercise.DifficultyLevel += weight;
            }
            else if (command == "Progress")
            {
                var muscleGroup = commandElements[0];

                if (exercises.Count(x => x.Group == muscleGroup) == 0)
                {
                    Console.WriteLine($"Group {muscleGroup} does not exist in the training plan");
                    continue;
                }

                exercises = exercises.Where(x => x.Group != muscleGroup).ToList();
            }
        }

        if (exercises.Count == 0)
        {
            Console.WriteLine("Training plan is under development!");
        }
        else
        {
            Console.WriteLine("Training Plan:");

            foreach (var exercise in exercises)
            {
                Console.WriteLine($" * {exercise.Name} hit {exercise.Group} and have difficulty level {exercise.DifficultyLevel}");
            }
        }
    }
}

// Created on: 05/12/2024 09:50:15