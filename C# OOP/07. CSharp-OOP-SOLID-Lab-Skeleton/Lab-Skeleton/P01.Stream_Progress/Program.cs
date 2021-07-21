using System;

namespace P01.Stream_Progress
{
    public class Program
    {
        static void Main()
        {
            var file = new StreamProgressInfo(new File("ImAFile", 10, 10));
            var music = new StreamProgressInfo(new Music("Lenny Kravitz","ImAnAlbum", 60, 3));
            var video = new StreamProgressInfo(new Video("ImFile", 3, 2));

            Console.WriteLine(file.CalculateCurrentPercent());
            Console.WriteLine(music.CalculateCurrentPercent());
            Console.WriteLine(video.CalculateCurrentPercent());
        }
    }
}
