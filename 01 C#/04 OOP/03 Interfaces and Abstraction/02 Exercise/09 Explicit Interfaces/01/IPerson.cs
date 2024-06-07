namespace ExplicitInterfaces
{
    public interface IPerson
    {
        public string Name { get; }

        public int Age { get; }

        string GetName() => Name;
    }
}
