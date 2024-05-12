namespace ConsoleApp
{
    public class CustomThreeuple<T, T2, T3>
    {
        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo} -> {ItemThree}";
        }

        public T ItemOne { get; set; }

        public T2 ItemTwo { get; set; }
        
        public T3 ItemThree { get; set; }
    }
}
