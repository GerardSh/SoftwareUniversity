class Program
{
    static void Main(string[] args)
    {
        //1. Create the Database
        var mongoService = new MongoDbService();
        mongoService.SeedArticles();

        //2. Read
        mongoService.PrintAllArticleNames();

        //3. Create a new article
        mongoService.AddNewArticle("Steve Jobs", "05-05-2005", "The story of Apple", 60);

        //4. Update
        mongoService.UpdateArticleRatings();

        //5. Delete
        mongoService.DeleteArticlesWithLowRating();
    }
}
