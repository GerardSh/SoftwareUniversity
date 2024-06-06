namespace BirthdayCelebrations
{
    public class Robot : IIdentifiable
    {
        public Robot(string model, string iD)
        {
            Model = model;
            Id = iD;
        }

        public string Id { get; set; }

        public string Model { get; set; }
    }
}
