using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Module4HW6.Converters;
using Module4HW6.Entities;
using Module4HW6.EntityConfigurations;

namespace Module4HW6
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<ArtistSong> ArtistSongs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArtistConfiguration());
            modelBuilder.ApplyConfiguration(new SongConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new ArtistSongConfiguration());
        }
        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>().HaveConversion<DateOnlyConverter>().HaveColumnType("date");
            builder.Properties<TimeOnly>().HaveConversion<TimeOnlyConverter>().HaveColumnType("time");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // does not work on migrations, use hard-code
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName)
                .AddJsonFile("appsettings.json")
                .Build();
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer(connectionString);

            // optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=Module4HW6Db;Trusted_Connection=True;");
        }
    }
}
