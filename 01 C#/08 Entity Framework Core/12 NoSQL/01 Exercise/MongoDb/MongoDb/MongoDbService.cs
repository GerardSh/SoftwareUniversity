using MongoDb;
using MongoDB.Driver;

public class MongoDbService
{
    private readonly IMongoCollection<Article> _articles;

    public MongoDbService()
    {
        var client = new MongoClient("mongodb://localhost:27017");
        var database = client.GetDatabase("Articles");
        _articles = database.GetCollection<Article>("articles");
    }

    public void SeedArticles()
    {
        var existingArticles = _articles.Find(FilterDefinition<Article>.Empty).ToList();

        var articlesToSeed = new List<Article>
        {
        new Article { Author = "Bill Gates", Date = "27-01-2020", Name = "Top 5 programming languages in 2020", Rating = 5 },
        new Article { Author = "Svetlin Nakov", Date = "02-05-2020", Name = "How to write bug-free code", Rating = 10 },
        new Article { Author = "Nikolay Kostov", Date = "08-07-2020", Name = "Set up your very own web server!", Rating = 20 },
        new Article { Author = "Elon Musk", Date = "17-04-2020", Name = "The future of space travel", Rating = 50 },
        new Article { Author = "Alen Paunov", Date = "10-07-2020", Name = "How to manage effectively", Rating = 50 }
        };

        foreach (var article in articlesToSeed)
        {
            var existingArticle = existingArticles.FirstOrDefault(a => a.Name == article.Name);

            if (existingArticle == null)
            {
                _articles.InsertOne(article);
            }
            else
            {
                Console.WriteLine($"Article already exists: {article.Name}");
            }
        }
    }

    public void PrintAllArticleNames()
    {
        var articles = _articles.Find(FilterDefinition<Article>.Empty).ToList();

        foreach (var article in articles)
        {
            Console.WriteLine(article.Name);
        }
    }

    public void AddNewArticle(string author, string date, string name, double rating)
    {
        var newArticle = new Article
        {
            Author = author,
            Date = date,
            Name = name,
            Rating = rating
        };

        _articles.InsertOne(newArticle);

        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Date: {date}");
        Console.WriteLine($"Name: {name}");

        if (rating % 1 == 0)
        {
            Console.WriteLine($"Rating: {rating:0}");
        }
        else
        {
            Console.WriteLine($"Rating: {rating}");
        }
    }

    public void UpdateArticleRatings()
    {
        var articles = _articles.Find(FilterDefinition<Article>.Empty).ToList();

        foreach (var article in articles)
        {
            article.Rating += 10;
            _articles.UpdateOne(a => a.Name == article.Name,
                Builders<Article>.Update.Set(a => a.Rating, article.Rating));
        }
    }

    public void DeleteArticlesWithLowRating()
    {
        var filter = Builders<Article>.Filter.Lte(a => a.Rating, 50);
        _articles.DeleteMany(filter);

        var remainingArticles = _articles.Find(FilterDefinition<Article>.Empty).ToList();

        foreach (var article in remainingArticles)
        {
            Console.WriteLine(article.Name);
        }
    }
}
