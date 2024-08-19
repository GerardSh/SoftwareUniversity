namespace Composite
{
    public class Program
    {
        public static void Main()
        {
            GiftBase gift = new SingleGift("Gift", 10.10m);
            GiftBase gift2 = new SingleGift("Gift2", 20.20m);

            decimal totalPrice = gift.CalculateTotalPrice();

            Console.WriteLine(totalPrice);

            CompositeGift compositeGift = new CompositeGift("Root", 0);

            compositeGift.Add(gift);
            compositeGift.Add(gift2);

            CompositeGift compositeGift2 = new CompositeGift("Root", 0);
            compositeGift2.Add(gift);
            compositeGift2.Add(gift2);

            compositeGift.Add(compositeGift2);

            totalPrice = compositeGift.CalculateTotalPrice();

            Console.WriteLine(totalPrice);
        }
    }
}