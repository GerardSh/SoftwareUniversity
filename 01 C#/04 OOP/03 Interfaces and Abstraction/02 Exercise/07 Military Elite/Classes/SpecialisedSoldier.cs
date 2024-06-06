namespace MilitaryElite
{
    public class SpecialisedSoldier : Soldier, ISpecialisedSoldier
    {

        public SpecialisedSoldier(string id, string firstName, string lastName, string corps)
            :base (id, firstName, lastName)
        {
            Corps = corps;
        }

        public string Corps { get; private set; }
    }
}
