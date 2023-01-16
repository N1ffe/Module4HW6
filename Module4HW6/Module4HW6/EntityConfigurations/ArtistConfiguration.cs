using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations
{
    public class ArtistConfiguration : IEntityTypeConfiguration<Artist>
    {
        public void Configure(EntityTypeBuilder<Artist> builder)
        {
            builder.ToTable("Artist").HasKey(a => a.Id);
            builder.Property(a => a.Id).ValueGeneratedOnAdd();
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.DateOfBirth).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(50);
            builder.Property(a => a.Email).HasMaxLength(50);
            builder.Property(a => a.InstagramUrl).HasMaxLength(100);

            builder.HasData(new List<Artist>()
            {
                new Artist() { Id = 1, Name = "test_artist_name1", DateOfBirth = new DateOnly(1998, 4, 14) },
                new Artist() { Id = 2, Name = "test_artist_name2", DateOfBirth = new DateOnly(1986, 11, 3) },
                new Artist() { Id = 3, Name = "test_artist_name3", DateOfBirth = new DateOnly(2002, 6, 22) },
                new Artist() { Id = 4, Name = "test_artist_name4", DateOfBirth = new DateOnly(1981, 1, 19) },
                new Artist() { Id = 5, Name = "test_artist_name5", DateOfBirth = new DateOnly(1999, 2, 5) }
            });
        }
    }
}
