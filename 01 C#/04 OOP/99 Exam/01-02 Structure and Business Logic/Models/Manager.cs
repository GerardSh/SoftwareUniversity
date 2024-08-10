using FootballManager.Models.Contracts;
using FootballManager.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballManager.Models
{
    public abstract class Manager : IManager
    {
        private string name;

        protected Manager(string name, double ranking)
        {
            Name = name;
            Ranking = ranking;
        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.ManagerNameNull);
                }

                name = value;
            }
        }

        public double Ranking { get; protected set; }

        public abstract void RankingUpdate(double updateValue);

        public override string ToString()
        {
            return $"{Name} - {GetType().Name} (Ranking: {Ranking:f2})";
        }
    }
}
