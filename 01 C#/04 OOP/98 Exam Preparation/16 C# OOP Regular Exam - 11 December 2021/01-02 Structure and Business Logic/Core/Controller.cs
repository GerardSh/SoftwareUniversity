using Gym.Core.Contracts;
using Gym.Models.Athletes;
using Gym.Models.Athletes.Contracts;
using Gym.Models.Equipment;
using Gym.Models.Equipment.Contracts;
using Gym.Models.Gyms;
using Gym.Models.Gyms.Contracts;
using Gym.Repositories;
using Gym.Repositories.Contracts;
using Gym.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gym.Core
{
    public class Controller : IController
    {
        IRepository<IEquipment> equipment;
        List<IGym> gym;

        public Controller()
        {
            equipment = new EquipmentRepository();
            gym = new List<IGym>();
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IAthlete athlete = null;

            if (athleteType == nameof(Boxer))
            {
                athlete = new Boxer(athleteName, motivation, numberOfMedals);
            }
            else if (athleteType == nameof(Weightlifter))
            {
                athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            IGym gym = this.gym.FirstOrDefault(x => x.Name == gymName);


            if (athleteType == nameof(Boxer) && gym.GetType().Name == nameof(WeightliftingGym)
                || athleteType == nameof(Weightlifter) && gym.GetType().Name == nameof(BoxingGym))
            {
                return string.Format(OutputMessages.InappropriateGym);
            }

            gym.AddAthlete(athlete);

            return string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;

            if (equipmentType == nameof(BoxingGloves))
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == nameof(Kettlebell))
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipment);

            return string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;

            if (gymType == nameof(BoxingGym))
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == nameof(WeightliftingGym))
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gym.Add(gym);

            return string.Format(OutputMessages.SuccessfullyAdded, gymType);
        }

        public string EquipmentWeight(string gymName)
        {
            double totalWeight = this.gym.FirstOrDefault(x => x.Name == gymName).EquipmentWeight;

            return string.Format(OutputMessages.EquipmentTotalWeight, gymName, totalWeight);
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.InexistentEquipment, equipmentType));
            }

            this.equipment.Remove(equipment);

            IGym gym = this.gym.FirstOrDefault(x => x.Name == gymName);

            gym.AddEquipment(equipment);

            return string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
        }

        public string Report()
        {
            var sb = new StringBuilder();

            foreach (var gym in this.gym)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().Trim();
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gym.FirstOrDefault(x => x.Name == gymName);

            gym.Exercise();

            return string.Format(OutputMessages.AthleteExercise, gym.Athletes.Count);
        }
    }
}