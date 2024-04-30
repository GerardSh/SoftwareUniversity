namespace Animals
{
    internal class Dog
    {
        public Dog()
        {

        }

        public Dog(int age, string name, string breed, string color)
        {
            Name = name;
            Breed = breed;
            this.age = age;
            this.color = color;
        }

        public string Name { get; set; }

        public string Breed { get; set; }

        public int Size { get; set; }     

        internal static string Country { get; set; }

        private readonly string color;

        private int age;

        public int Age
        {
            get
            {
                return age;
            }
            set
            {
                age = value;
            }
        }

        /// <summary>
        /// The dog will bark.
        /// </summary>
        public void Bark()
        {
            Console.WriteLine("Bau");
        }
    }
}