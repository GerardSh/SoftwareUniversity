using RobotService.Core.Contracts;
using RobotService.Models;
using RobotService.Models.Contracts;
using RobotService.Repositories;
using RobotService.Repositories.Contracts;
using RobotService.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RobotService.Core
{
    public class Controller : IController
    {
        IRepository<ISupplement> supplements;
        IRepository<IRobot> robots;

        public Controller()
        {
            supplements = new SupplementRepository();
            robots = new RobotRepository();
        }

        public string CreateRobot(string model, string typeName)
        {
            IRobot robot = null;

            if (typeName == nameof(DomesticAssistant))
            {
                robot = new DomesticAssistant(model);
            }
            else if (typeName == nameof(IndustrialAssistant))
            {
                robot = new IndustrialAssistant(model);
            }
            else
            {
                return string.Format(OutputMessages.RobotCannotBeCreated, typeName);
            }

            robots.AddNew(robot);

            return string.Format(OutputMessages.RobotCreatedSuccessfully, typeName, model);
        }

        public string CreateSupplement(string typeName)
        {
            ISupplement supplement = null;

            if (typeName == nameof(SpecializedArm))
            {
                supplement = new SpecializedArm();
            }
            else if (typeName == nameof(LaserRadar))
            {
                supplement = new LaserRadar();
            }
            else
            {
                return string.Format(OutputMessages.SupplementCannotBeCreated, typeName);
            }

            supplements.AddNew(supplement);

            return string.Format(OutputMessages.SupplementCreatedSuccessfully, typeName);
        }

        public string PerformService(string serviceName, int intefaceStandard, int totalPowerNeeded)
        {
            var supportedRobots = robots.Models().Where(x => x.InterfaceStandards.Any(x => x == intefaceStandard));

            if (!supportedRobots.Any())
            {
                return string.Format(OutputMessages.UnableToPerform, intefaceStandard);
            }

            var sortedRobots = supportedRobots.OrderByDescending(x => x.BatteryLevel);

            int sumBatteryLevel = sortedRobots.Sum(x => x.BatteryLevel);

            if (sumBatteryLevel < totalPowerNeeded)
            {
                return string.Format(OutputMessages.MorePowerNeeded, serviceName, totalPowerNeeded - sumBatteryLevel);
            }

            int robotCount = 0;

            foreach (var robot in sortedRobots)
            {
                if (robot.BatteryLevel < totalPowerNeeded)
                {
                    totalPowerNeeded -= robot.BatteryLevel;
                    robot.ExecuteService(robot.BatteryLevel);
                    robotCount++;
                }
                else
                {
                    robot.ExecuteService(totalPowerNeeded);
                    robotCount++;

                    break;
                }
            }

            return string.Format(OutputMessages.PerformedSuccessfully, serviceName, robotCount);
        }

        public string Report()
        {
            var sortedRobots = robots.Models().OrderByDescending(x => x.BatteryLevel).ThenBy(x => x.BatteryCapacity);
            var sb = new StringBuilder();

            foreach (var robot in sortedRobots)
            {
                sb.AppendLine(robot.ToString());
            }

            return sb.ToString().Trim();
        }

        public string RobotRecovery(string model, int minutes)
        {
            var robotsToRecover = robots.Models().Where(x => x.Model == model && x.BatteryLevel < x.BatteryCapacity / 2).ToList();

            foreach (var robot in robotsToRecover)
            {
                robot.Eating(minutes);
            }

            return string.Format(OutputMessages.RobotsFed, robotsToRecover.Count());
        }

        public string UpgradeRobot(string model, string supplementTypeName)
        {
            ISupplement supplement = supplements.Models().FirstOrDefault(x => x.GetType().Name == supplementTypeName);
            int interfaceValue = supplement.InterfaceStandard;

            var robotToUpgrade = robots.Models().FirstOrDefault(x => !x.InterfaceStandards.Any(x => x == interfaceValue) && x.Model == model);

            if (robotToUpgrade == null)
            {
                return string.Format(OutputMessages.AllModelsUpgraded, model);
            }

            robotToUpgrade.InstallSupplement(supplement);

            supplements.RemoveByName(supplementTypeName);

            return string.Format(OutputMessages.UpgradeSuccessful, model, supplementTypeName);
        }
    }
}
