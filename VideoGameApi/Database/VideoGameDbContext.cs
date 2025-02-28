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
        public DbSet<VideoGameDetails> VideoGameDetails { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<VideoGame>().HasData(
              
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS5",
                
            },

            new VideoGame
            {
                Id = 2,
                Title = "The Legend of Zelda: Breath of the Wild",
                Platform = "Nintendo Switch",
               
            },

            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC",
               
            }

          );
        }
    }
}
