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


        internal void Edit(string newContent)
        {
            Content = newContent;
        }

        internal void ChangeAuthor(string newAuthor)
        {
            Author = newAuthor;
        }

        internal void Rename(string newTitle)
        {
            Title = newTitle;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }

    class Program
    {
        static void Main()
        {
            string[] articleData = Console.ReadLine().Split(", ");

            int n = int.Parse(Console.ReadLine());

            Article article = new Article(articleData[0], articleData[1], articleData[2]);

            for (int i = 0; i < n; i++)
            {
                string[] commands = Console.ReadLine().Split(":", StringSplitOptions.RemoveEmptyEntries);

                string command = commands[0];
                string newContent = commands[1];

                command = command.Trim();
                newContent = newContent.Trim();

                if (command == "Edit")
                {
                    article.Edit(newContent);
                }
                else if (command == "ChangeAuthor")
                {
                    article.ChangeAuthor(newContent);
                }
                else
                {
                    article.Rename(newContent);
                }
            }

            Console.WriteLine(article);
        }

    }
}