namespace Module4HW6.Entities
{
    public class Artist
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? InstagramUrl { get; set; }
        public virtual List<ArtistSong> ArtistSongs { get; set; } = new List<ArtistSong>();
    }
}
