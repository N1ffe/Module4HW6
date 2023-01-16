using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {
        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("ArtistSong").HasKey(asg => asg.Id);
            builder.Property(asg => asg.Id).ValueGeneratedOnAdd();
            builder.HasOne(asg => asg.Artist).WithMany(a => a.ArtistSongs).HasForeignKey(asg => asg.ArtistId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(asg => asg.Song).WithMany(s => s.ArtistSongs).HasForeignKey(asg => asg.SongId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<ArtistSong>()
            {
                new ArtistSong() { Id = 1, ArtistId = 1, SongId = 1 },
                new ArtistSong() { Id = 2, ArtistId = 2, SongId = 1 },
                new ArtistSong() { Id = 3, ArtistId = 3, SongId = 2 },
                new ArtistSong() { Id = 4, ArtistId = 4, SongId = 3 },
                new ArtistSong() { Id = 5, ArtistId = 5, SongId = 3 },
                new ArtistSong() { Id = 6, ArtistId = 3, SongId = 4 },
                new ArtistSong() { Id = 7, ArtistId = 1, SongId = 5 }
            });
        }
    }
}