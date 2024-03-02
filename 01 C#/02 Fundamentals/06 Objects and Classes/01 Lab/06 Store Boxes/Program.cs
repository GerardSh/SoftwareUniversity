namespace ConsoleApp
{
    class Item
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
    class Box
    {
        public string SerialNumber { get; set; }

        public Item Item { get; set; }

        public int ItemQuantity { get; set; }

        public double MyProperty2 { get; set; }

        public double CalculateBoxPrice()
        {
            return Item.Price * ItemQuantity;
        }

        public override string ToString()
        {
            return
    $@"{SerialNumber}  
-- {Item.Name} - ${Item.Price:f2}: {ItemQuantity}
-- ${Item.Price * ItemQuantity:f2}";
        }
    }

    class Program
    {
        static void Main()
        {
            string input;

            List<Box> boxes = new List<Box>();

            while ((input = Console.ReadLine()) != "end")
            {
                string[] itemData = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string serialNumber = itemData[0];
                string itemName = itemData[1];
                int itemQuantity = int.Parse(itemData[2]);
                double itemPrice = double.Parse(itemData[3]);
                double boxPrice = itemQuantity * itemPrice;

                Box box = new Box()
                {
                    SerialNumber = serialNumber,
                    ItemQuantity = itemQuantity,
                    Item = new Item()
                    {
                        Name = itemName,
                        Price = itemPrice,
                    }
                };

                boxes.Add(box);
            }
            boxes = boxes.OrderByDescending(b => b.CalculateBoxPrice()).ToList();

            foreach (Box box in boxes)
            {
                Console.WriteLine(box);
            }
        }
    }
}