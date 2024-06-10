namespace Shapes
{
    public class StartUp
    {
        public static void Main()
        {
            Shape circle = new Circle(5);
            circle.Draw();
            Shape rectangle = new Rectangle(10, 10);
            rectangle.Draw();
        }
    }
}
