namespace ConsoleApp
{
    class Article
    {
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Author { get; set; }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>(n);

            for (int i = 0; i < n; i++)
            {
                string[] articleData = Console.ReadLine().Split(", ");

                Article article = new Article(articleData[0], articleData[1], articleData[2]);
                articles.Add(article);
            }

            string sort = Console.ReadLine();

            if (sort == "title")
            {
                articles = articles.OrderBy(x => x.Title).ToList();
            }
            else if (sort == "content")
            {
                articles = articles.OrderBy(x => x.Content).ToList();
            }
            else if (sort == "author")
            {
                articles = articles.OrderBy(x => x.Author).ToList();
            }

            foreach (Article article in articles)
            {
                Console.WriteLine(article);
            }
        }
    }
}