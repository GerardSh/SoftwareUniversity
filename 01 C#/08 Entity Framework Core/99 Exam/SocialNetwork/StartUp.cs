using Microsoft.EntityFrameworkCore;
using SocialNetwork.Data;

namespace SocialNetwork
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SocialNetworkDbContext dbContext = new SocialNetworkDbContext();

            ResetDatabase(dbContext, shouldDropDatabase: true);

            var projectDir = GetProjectDirectory();

            ImportEntities(dbContext, projectDir + @"Datasets/", projectDir + @"ImportResults/");
            ExportEntities(dbContext, projectDir + @"ExportResults/");

            using (var transaction = dbContext.Database.BeginTransaction())
            {
                transaction.Rollback();
            }
        }

        private static void ImportEntities(SocialNetworkDbContext dbContext, string baseDir, string exportDir)
        {
            var messages = DataProcessor.Deserializer
                .ImportMessages(dbContext, File.ReadAllText(baseDir + "messages.xml"));

            PrintAndExportEntityToFile(messages, exportDir + "ActualResult_ImportMessages.txt");

            var posts = DataProcessor.Deserializer
                .ImportPosts(dbContext, File.ReadAllText(baseDir + "posts.json"));

            PrintAndExportEntityToFile(posts, exportDir + "ActualResult_ImportPosts.txt");
        }

        private static void ExportEntities(SocialNetworkDbContext dbContext, string exportDir)
        {
            var UsersWithTheirPosts = DataProcessor.Serializer
                .ExportUsersWithFriendShipsCountAndTheirPosts(dbContext);

            Console.WriteLine(UsersWithTheirPosts);
            File.WriteAllText(exportDir + "ActualResult_ExportUsersWithTheirPosts.xml", UsersWithTheirPosts);

            var Conversations = DataProcessor.Serializer
                .ExportConversationsWithMessagesChronologically(dbContext);

            Console.WriteLine(Conversations);
            File.WriteAllText(exportDir + "ActualResult_ExportConversationsWithMessages.json", Conversations);
        }

        private static void PrintAndExportEntityToFile(string entityOutput, string outputPath)
        {
            Console.WriteLine(entityOutput);
            File.WriteAllText(outputPath, entityOutput.TrimEnd());
        }

        private static object GetProjectDirectory()
        {
            var directory = Directory.GetCurrentDirectory();
            var directoryName = Path.GetFileName(directory);
            var relativePath  = directoryName.StartsWith("net6.0") ? @"../../../" : string.Empty;

            return relativePath;
        }

        private static void ResetDatabase(SocialNetworkDbContext dbContext, bool shouldDropDatabase = false)
        {
            if (shouldDropDatabase)
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
            }
            else
            {
                if (dbContext.Database.EnsureCreated())
                {
                    return;
                }

                string disableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
                dbContext.Database.ExecuteSqlRaw(disableIntegrityChecksQuery);

                string deleteRowsQuery = "EXEC sp_MSforeachtable @command1='SET QUOTED_IDENTIFIER ON;DELETE FROM ?'";
                dbContext.Database.ExecuteSqlRaw(deleteRowsQuery);

                string enableIntegrityChecksQuery = "EXEC sp_MSforeachtable @command1='ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";
                dbContext.Database.ExecuteSqlRaw(enableIntegrityChecksQuery);

                string reseedQuery = "EXEC sp_MSforeachtable @command1='IF OBJECT_ID(''?'') IN (SELECT OBJECT_ID FROM SYS.IDENTITY_COLUMNS) DBCC CHECKIDENT(''?'', RESEED, 0)'";
                dbContext.Database.ExecuteSqlRaw(reseedQuery);
            }
        }
    }
}
