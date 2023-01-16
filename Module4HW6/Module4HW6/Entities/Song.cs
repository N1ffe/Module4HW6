namespace Module4HW6.Entities
{
    public class Song
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeOnly Duration { get; set; }
        public DateOnly ReleasedDate { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
        public virtual List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
