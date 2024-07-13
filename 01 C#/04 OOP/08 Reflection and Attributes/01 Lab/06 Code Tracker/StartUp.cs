namespace AuthorProblem
{
    [Author("Gerard")]
    public class StartUp
    {
        [Author("Gerard")]
        [Author("SoftUni")]
        static void Main(string[] args)
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();
        }
    }
}