namespace IteratorsAndComparators
{
    public class Book : IComparable<Book>
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

        public int CompareTo(Book? other)
        {
            if (Year > other.Year)
            {
                return 1;
            }
            else if (Year < other.Year)
            {
                return -1;
            }
            else
            {
                return Title.CompareTo(other.Title);
            }
        }
    }
}