namespace IteratorsAndComparators
{
    public class Book
    {
        public override string ToString()
        {
            return $"{Title} - {Year}";
        }

        public Book(string title, int year, params string[] authors)
        {
            Title = title;
            Year = year;
            Authors = authors;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors { get; set; }
    }
}