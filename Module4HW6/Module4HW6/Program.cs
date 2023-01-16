using Microsoft.EntityFrameworkCore;

namespace Module4HW6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var query1 = db.ArtistSongs.Select(s => new { Name = s.Song.Title, ArtistName = s.Artist.Name, Genre = s.Song.Genre.Title });
                Console.WriteLine(query1.ToQueryString());
                Console.WriteLine();
                foreach (var s in query1.ToList())
                {
                    Console.WriteLine($"{s.Name} {s.ArtistName} {s.Genre}");
                }
                Console.WriteLine();

                var query2 = db.Songs.GroupBy(s => s.Genre).Select(s => new { Genre = s.Key.Title, Songs = s.Count() });
                Console.WriteLine(query2.ToQueryString());
                Console.WriteLine();
                foreach (var s in query2.ToList())
                {
                    Console.WriteLine($"{s.Genre} {s.Songs}");
                }
                Console.WriteLine();

                var query3 = db.Songs.Where(s => s.ReleasedDate < db.Artists.Min(a => a.DateOfBirth));
                Console.WriteLine(query3.ToQueryString());
                Console.WriteLine();
                foreach (var s in query3.ToList())
                {
                    Console.WriteLine($"{s.Title} {s.Duration} {s.ReleasedDate} {s.Genre.Title}");
                }
                Console.WriteLine();
            }
        }
    }
}