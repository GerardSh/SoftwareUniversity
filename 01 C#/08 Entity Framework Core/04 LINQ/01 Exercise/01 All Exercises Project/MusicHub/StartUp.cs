namespace MusicHub
{
    using System;
    using System.Text;
    using Data;
    using Initializer;
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class StartUp
    {
        static StringBuilder sb = new StringBuilder();

        public static void Main()
        {
            using MusicHubDbContext context =
                  new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            //Test your solutions here
            //Console.WriteLine(ExportAlbumsInfo(context, 9));
            //Console.WriteLine(ExportSongsAboveDuration(context, 4));
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var albums = context
                .Albums
                .Where(a => a.ProducerId.HasValue &&
                            a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate.ToString("MM/dd/yyyy"),
                    ProducerName = a.Producer!.Name, // Justification: Only albums with Producer are filtered
                    Songs = a.Songs
                             .Select(s => new
                             {
                                 SongName = s.Name,
                                 SongPrice = s.Price,
                                 SongWriter = s.Writer.Name
                             })
                            .OrderByDescending(s => s.SongName)
                            .ThenBy(s => s.SongWriter)
                            .ToArray(),
                    AlbumPrice = a.Songs.Sum(s => s.Price)
                })
                //.OrderByDescending(a => a.Songs.Sum(s => s.SongPrice)) // Sorted in SQL
                .ToArray();

            sb.Clear();

            // Here Albums are in-memory array (implementing IEnumerable<T>) =>
            // we can perform in-program memory ordering based on the calculated property
            foreach (var album in albums.OrderByDescending(a => a.AlbumPrice))
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine($"-Songs:");

                int i = 1;

                foreach (var song in album.Songs)
                {
                    sb.AppendLine($"---#{i++}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.SongPrice:f2}");
                    sb.AppendLine($"---Writer: {song.SongWriter}");
                }

                sb.AppendLine($"-AlbumPrice: {album.AlbumPrice:f2}");
            }

            return sb.ToString().Trim();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            var songs = context.Songs
                .Where(s => s.Duration > TimeSpan.FromSeconds(duration))
                .Select(s => new
                {
                    Name = s.Name,
                    Performers = s.SongPerformers
                                .Select(sp => sp.Performer.FirstName + " " + sp.Performer.LastName)
                                .OrderBy(p => p)
                                .ToArray(),
                    WriterName = s.Writer.Name,
                    AlbumProducer = s.Album != null && s.Album.Producer != null ? s.Album.Producer.Name : null,
                    Duration = s.Duration.ToString("c")
                })
                .OrderBy(s => s.Name)
                .ThenBy(s => s.WriterName)
                .ToList();

            sb.Clear();

            int i = 1;

            foreach (var song in songs)
            {
                sb.AppendLine($"-Song #{i++}");
                sb.AppendLine($"---SongName: {song.Name}");
                sb.AppendLine($"---Writer: {song.WriterName}");

                foreach (var p in song.Performers)
                {
                    sb.AppendLine($"---Performer: {p}");
                }

                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration}");
            }

            return sb.ToString().Trim();
        }
    }
}
