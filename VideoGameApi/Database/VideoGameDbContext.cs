using Microsoft.EntityFrameworkCore;
using VideoGameApi.Entites;

namespace VideoGameApi.Database
{
    public class VideoGameDbContext:DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext>options):base(options)
        {
    
        }

        public VideoGameDbContext()
        {

        }



        public DbSet<VideoGame> VideoGames { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                string connectionString = configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}
