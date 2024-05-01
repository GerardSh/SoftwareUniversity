namespace DefiningClasses
{
    public class Family
    {
        public List<Person> People { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember() => People.OrderByDescending(x => x.Age).FirstOrDefault();
    }
}
