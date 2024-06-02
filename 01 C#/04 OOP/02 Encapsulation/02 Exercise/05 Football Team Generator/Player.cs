namespace FootballTeamGenerator
{
    public class Player
    {
        double skill;
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

            skill = (Endurance + Spring + Dribbel + Passing + Shooting) / 5.0 ;
        }

        public string Name
        {
            get => name;
            set
            {  
                name = value;
            }
        }

        public int Endurance
        {
            get => endurance; set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                endurance = value;
            }
        }

        public int Spring
        {
            get => spring; set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Spring should be between 0 and 100.");
                }

                spring = value;
            }
        }

        public int Dribbel
        {
            get => dribbel; set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Dribbel should be between 0 and 100.");
                }

                dribbel = value;
            }
        }

        public int Passing
        {
            get => passing; set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                passing = value;
            }
        }

        public int Shooting
        {
            get => shooting; set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                shooting = value;
            }
        }
    }
}
