namespace MilitaryElite
{
    public class Program
    {
        public static void Main()
        {
            string input;
            var iSoldiersById = new Dictionary<string, ISoldier>();

            while ((input = Console.ReadLine()) != "End")
            {
                string[] elements = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string soldierUnit = elements[0];

                string id = elements[1];
                string firstName = elements[2];
                string lastName = elements[3];

                if (soldierUnit == "Private")
                {
                    decimal salary = decimal.Parse(elements[4]);

                    Private @private = new Private(id, firstName, lastName, salary);
                    iSoldiersById[id] = @private;
                }
                else if (soldierUnit == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(elements[4]);

                    List<string> idNumbers = elements.Skip(4).ToList();

                    LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    foreach (string idNumber in idNumbers)
                    {                   
                        if (iSoldiersById.ContainsKey(idNumber) )
                        {
                            lieutenantGeneral.AddPrivate((Private)iSoldiersById[idNumber]);
                        }
                    }

                    iSoldiersById[id] = lieutenantGeneral;
                }
                else if (soldierUnit == "Spy")
                {
                    int codeNumber = int.Parse(elements[4]);

                    Spy spy = new Spy(id, firstName, lastName, codeNumber);

                    iSoldiersById[id] = spy;
                }
                else if (soldierUnit == "Engineer")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string corps = elements[5];

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }

                    Engineer engineer = new Engineer(id, firstName, lastName, salary, corps);
                    List<string> repairElements = elements.Skip(6).ToList();

                    for (int i = 1; i < repairElements.Count; i += 2)
                    {
                        engineer.Repairs.Add(new Repair(repairElements[i - 1], int.Parse(repairElements[i])));
                    }

                    iSoldiersById[id] = engineer;

                }
                else if (soldierUnit == "Commando")
                {
                    decimal salary = decimal.Parse(elements[4]);
                    string corps = elements[5];

                    if (corps != "Airforces" && corps != "Marines")
                    {
                        continue;
                    }

                    Commando commando = new Commando(id, firstName, lastName, salary, corps);

                    List<string> missionElements = elements.Skip(6).ToList();

                    for (int i = 1; i < missionElements.Count; i += 2)
                    {
                        if (missionElements[i] != "inProgress" && missionElements[i] != "Finished")
                        {
                            continue;
                        }

                        commando.Missions.Add(new Mission(missionElements[i - 1], missionElements[i]));
                    }

                    iSoldiersById[id] = commando;
                }            
            }

            foreach (var kvp in iSoldiersById)
            {
                Console.WriteLine(kvp.Value.ToString());
            }
        }
    }
}