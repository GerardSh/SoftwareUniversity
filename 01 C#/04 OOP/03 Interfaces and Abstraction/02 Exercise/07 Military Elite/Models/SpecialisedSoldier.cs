namespace MilitaryElite
{
    public class SpecialisedSoldier : Private, ISpecialisedSoldier
    {

        public SpecialisedSoldier(string id, string firstName, string lastName, string corps, decimal salary)
            :base (id, firstName, lastName, salary)
        {
            Corps = corps;
        }

        public string Corps { get; private set; }
    }
}
