using Template_Pattern;

namespace Template
{
    public class Program
    {
        public static void Main()
        {
            Bread twelveGrain = new TwelveGrain();
            Bread wholeWheat = new WholeWheat();
            Bread sourdough = new Sourdough();

            twelveGrain.Make();
            wholeWheat.Make();
            sourdough.Make();
        }
    }
}