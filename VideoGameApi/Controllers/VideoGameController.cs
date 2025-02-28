using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VideoGameApi.Database;
using VideoGameApi.Entites;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {

        private readonly VideoGameDbContext _context;

        public VideoGameController(VideoGameDbContext context)
        {
            _context = context;
        }
        //static private List<VideoGame> videoGames = new List<VideoGame>
        //{
        //    new VideoGame
        //    {
        //        Id = 1,
        //        Title = "Spider-Man 2",
        //        Platform = "PS5",
        //        Developer = "Insomniac Games",
        //        Publisher = "Sony Interactive Entertainment"
        //    },

        //    new VideoGame
        //    {
        //        Id = 2,
        //        Title = "The Legend of Zelda: Breath of the Wild",
        //        Platform = "Nintendo Switch",
        //        Developer = "Nintendo EPD",
        //        Publisher = "Nintendo"
        //    },

        //    new VideoGame
        //    {
        //        Id = 3,
        //        Title = "Cyberpunk 2077",
        //        Platform = "PC",
        //        Developer = "CD Projekt Red",
        //        Publisher = "CD Projekt"
        //    },
        //};

        [HttpGet]

        //IEnumerable dediğimiz yapı liste içinde dönmemizi sağlar.
        //ActionResult ise dönüş tipidir. IActionResult'dan türetilmiştir. hata durumlarını kontrol etmemizi sağlar.
        public async Task<ActionResult<List<VideoGame>>> GetVideoGames()
        {
            return Ok(await _context.VideoGames.ToListAsync());
        }


        //Route ile urller belirleniyor.
        //id ile gelen parametreleri alıyoruz.
        //Task ile asenkron çalışma sağlıyoruz. task dönüş tipidir.
        [HttpGet]
        [Route("{id}")]

        public async Task<ActionResult<VideoGame>> GetVideoGameById(int id) 
        {
            var game = await _context.VideoGames.FindAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            return Ok(game);
        }

        [HttpPost]

        public async Task<ActionResult<VideoGame>> AddVideoGame(VideoGame newGame)
        {
            if (newGame == null)
            {
                return BadRequest();
            }

            _context.VideoGames.Add(newGame);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetVideoGameById), new { id = newGame.Id }, newGame);

        }

        [HttpPut("{id}")]
        

        public async Task<IActionResult> UpdateVideoGame(int id , VideoGame updatesGame)

        {
            var game = await _context.VideoGames.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            game.Title = updatesGame.Title;
            game.Platform = updatesGame.Platform;
            game.Developer = updatesGame.Developer;
            game.Publisher = updatesGame.Publisher;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteVideoGame(int id)
        {
            var game = await _context.VideoGames.FindAsync(id);

            if (game == null)
            {
                return NotFound();
            }

            _context.VideoGames.Remove(game);
            await _context.SaveChangesAsync();
            return NoContent();

        }
    }
}
