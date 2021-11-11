namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            Console.WriteLine(ExportSongsAboveDuration(context, 4));

            //Test your solutions here
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            StringBuilder result = new StringBuilder();

            var albumsInfo = context.Albums
                .Where(a => a.ProducerId == producerId)
                .Select(a => new 
                { 
                    AlbumName = a.Name,
                    ReleaseDate = a.ReleaseDate,
                    ProducerName = a.Producer.Name,
                    Songs = a.Songs
                        .Select(s => new 
                        {
                            SongName = s.Name,
                            SongPrice = s.Price,
                            SongWriter = s.Writer.Name
                        }),
                    AlbumPrice = a.Price
                })
                .ToList();

            foreach (var album in albumsInfo
                                     .OrderByDescending(a => a.AlbumPrice))
            {
                result.AppendLine($"-AlbumName: {album.AlbumName}");
                result.AppendLine($"-ReleaseDate: {album.ReleaseDate:MM/dd/yyyy}");
                result.AppendLine($"-ProducerName: {album.ProducerName}");
                result.AppendLine($"-Songs:");

                int songsCount = 0;
                foreach (var song in album.Songs
                                          .OrderByDescending(s => s.SongName)
                                          .ThenBy(s => s.SongWriter))
                {                                         
                    songsCount++;
                    result.AppendLine($"---#{songsCount}");
                    result.AppendLine($"---SongName: {song.SongName}");
                    result.AppendLine($"---Price: {song.SongPrice:F2}");
                    result.AppendLine($"---Writer: {song.SongWriter}");
                }

                result.AppendLine($"-AlbumPrice: {album.AlbumPrice:F2}");
            }        

            return result.ToString().TrimEnd();
        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder result = new StringBuilder();

            var songs = context.Songs
                .Where(s => s.Duration > new TimeSpan(0, 0, 0, duration))
                .Select(s => new
                {
                    Name = s.Name,
                    PerformerFullName = s.SongPerformers
                        .Select(sp => string.Concat(sp.Performer.FirstName, " ", sp.Performer.LastName))
                        .FirstOrDefault(),
                    Writer = s.Writer.Name,
                    AlbumProducer = s.Album.Producer.Name,
                    Duration = s.Duration
                })
                .ToList()
                .OrderBy(s => s.Name)
                .ThenBy(s => s.Writer)
                .ThenBy(s => s.PerformerFullName)
                .ToList();

            int songNum = 0;

            foreach (var song in songs)
            {
                songNum++;

                result.AppendLine($"-Song #{songNum}");
                result.AppendLine($"---SongName: {song.Name}");
                result.AppendLine($"---Writer: {song.Writer}");
                result.AppendLine($"---Performer: {song.PerformerFullName}");
                result.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                result.AppendLine($"---Duration: {song.Duration.ToString("c")}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
