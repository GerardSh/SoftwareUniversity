namespace ConsoleApp
{
    public class CustomTuple<T,T2>
    {
        public override string ToString()
        {
            return $"{ItemOne} -> {ItemTwo}";
        }

        public T ItemOne { get; set; }

        public T2 ItemTwo { get; set; }
    }
}
