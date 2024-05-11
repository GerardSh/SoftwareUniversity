namespace ConsoleApp
{
    public class Box<T>
    {
        public Box(T value) 
        { 
        this.value = value;
        }

        public override string ToString()
        {
            return $"{typeof(T)}: {value}";
        }

        T value;
    }
}