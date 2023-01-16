using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4HW6.Entities;

namespace Module4HW6.EntityConfigurations
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable("Genre").HasKey(g => g.Id);
            builder.Property(g => g.Id).ValueGeneratedOnAdd();
            builder.Property(g => g.Title).IsRequired().HasMaxLength(50);

            builder.HasData(new List<Genre>()
            {
                new Genre() { Id = 1, Title = "test_genre1" },
                new Genre() { Id = 2, Title = "test_genre2" },
                new Genre() { Id = 3, Title = "test_genre3" },
                new Genre() { Id = 4, Title = "test_genre4" },
                new Genre() { Id = 5, Title = "test_genre5" }
            });
        }
    }
}