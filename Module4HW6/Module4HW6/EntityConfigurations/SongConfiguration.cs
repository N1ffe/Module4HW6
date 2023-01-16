using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations
{
    public class SongConfiguration : IEntityTypeConfiguration<Song>
    {
        public void Configure(EntityTypeBuilder<Song> builder)
        {
            builder.ToTable("Song").HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();
            builder.Property(s => s.Title).IsRequired().HasMaxLength(100);
            builder.Property(s => s.Duration).IsRequired();
            builder.Property(s => s.ReleasedDate).IsRequired();
            builder.HasOne(s => s.Genre).WithMany(g => g.Songs).HasForeignKey(s => s.GenreId).OnDelete(DeleteBehavior.Cascade);

            builder.HasData(new List<Song>()
            {
                new Song() { Id = 1, Title = "test_song_name1", Duration = new TimeOnly(0, 3, 24), ReleasedDate = new DateOnly(2021, 11, 8), GenreId = 3 },
                new Song() { Id = 2, Title = "test_song_name2", Duration = new TimeOnly(0, 2, 51), ReleasedDate = new DateOnly(2022, 4, 16), GenreId = 2 },
                new Song() { Id = 3, Title = "test_song_name3", Duration = new TimeOnly(0, 2, 36), ReleasedDate = new DateOnly(2022, 3, 24), GenreId = 5 },
                new Song() { Id = 4, Title = "test_song_name4", Duration = new TimeOnly(0, 3, 44), ReleasedDate = new DateOnly(2021, 10, 15), GenreId = 4 },
                new Song() { Id = 5, Title = "test_song_name5", Duration = new TimeOnly(0, 3, 11), ReleasedDate = new DateOnly(2022, 8, 2), GenreId = 1 }
            });
        }
    }
}
