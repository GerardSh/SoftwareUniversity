namespace BirthdayCelebrations
{
    public class Pet : IBirthdateable
    {
        public Pet(string name, string birthdate)
        {
            Name = name;
            Birthdate = birthdate;
        }

        public string Name { get; set; }

        public string Birthdate { get; set; }
    }
}
