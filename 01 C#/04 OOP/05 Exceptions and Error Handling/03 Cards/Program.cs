namespace ConsoleApp
{
    public class Card
    {
        public Card(string face, string suit)
        {
            //1
            //if (!((face == "10" || (face.Length == 1 && (char.Parse(face) >= '2' && char.Parse(face) <= '9' || face == "J" || face == "Q" || face == "K" || face == "A") &&
            //    (suit == "S" || suit == "H" || suit == "D" || suit == "C")))))

            //2
            if (!(face == "10" || face == "2" || face == "3" || face == "4" || face == "5" || face == "6" || face == "7" || face == "8" || face == "9" || face == "J" || face == "Q" || face == "K" || face == "A") &&
               (suit == "S" || suit == "H" || suit == "D" || suit == "C"))
            {
                throw new ArgumentException("Invalid card!");
            }

            Face = face;
            Suit = suit;
        }

        public string Face { get; set; }

        public string Suit { get; set; }

        public override string ToString()
        {
            {
                return $"[{Face}{(Suit == "S" ? "\u2660" : Suit == "H" ? "\u2665" : Suit == "D" ? "\u2666" : "\u2663")}]";
            }
        }
    }

    public class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            List<Card> cards = new List<Card>(input.Length);

            foreach (string line in input)
            {
                string[] cardElements = line.Split();
                try
                {
                    Card card = new Card(cardElements[0], cardElements[1]);
                    cards.Add(card);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}