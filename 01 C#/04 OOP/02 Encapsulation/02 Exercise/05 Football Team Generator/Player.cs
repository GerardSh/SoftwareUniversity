namespace FootballTeamGenerator
{
    public class Player
    {
        const int MinSkill = 0;
        const int MaxSkill = 100;

        private string name;
        private int endurance;
        private int spring;
        private int dribbel;
        private int passing;
        private int shooting;

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Spring = sprint;
            Dribbel = dribble;
            Passing = passing;
            Shooting = shooting;
        }

        public string Name
        {
            get => name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                name = value;
            }
        }

        public int Endurance
        {
            get => endurance; set
            {
                ValidateValue(value, nameof(Endurance));
                endurance = value;
            }
        }

        public int Spring
        {
            get => spring; set
            {

                ValidateValue(value, nameof(Spring));
                spring = value;
            }
        }

        public int Dribbel
        {
            get => dribbel; set
            {
                ValidateValue(value, nameof(Dribbel));
                dribbel = value;
            }
        }

        public int Passing
        {
            get => passing; set
            {
                ValidateValue(value, nameof(Passing));
                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting; set
            {
                ValidateValue(value, nameof(Shooting));
                shooting = value;
            }
        }

        public double Skill => (Endurance + Spring + Dribbel + Passing + Shooting) / 5.0;

        void ValidateValue(int value, string skillName)
        {
            if (value < MinSkill || value > MaxSkill)
            {
                throw new ArgumentException($"{skillName} should be between {MinSkill} and {MaxSkill}.");
            }
        }
    }
}
