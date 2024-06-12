namespace WildFarm
{
    public abstract class Food
    {
        protected Food(int quanityty)
        {
            Quantity = quanityty;
        }

        public int Quantity { get; set; }  
    }
}
