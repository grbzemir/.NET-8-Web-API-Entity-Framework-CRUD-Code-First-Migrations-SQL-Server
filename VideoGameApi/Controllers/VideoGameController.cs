using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoGameApi.Entites;

namespace VideoGameApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoGameController : ControllerBase
    {
        static private List<VideoGame> videoGames = new List<VideoGame>
        {
            new VideoGame
            {
                Id = 1,
                Title = "Spider-Man 2",
                Platform = "PS5",
                Developer = "Insomniac Games",
                Publisher = "Sony Interactive Entertainment"
            },

            new VideoGame
            {
                Id = 2,
                Title = "The Legend of Zelda: Breath of the Wild",
                Platform = "Nintendo Switch",
                Developer = "Nintendo EPD",
                Publisher = "Nintendo"
            },

            new VideoGame
            {
                Id = 3,
                Title = "Cyberpunk 2077",
                Platform = "PC",
                Developer = "CD Projekt Red",
                Publisher = "CD Projekt"
            },
        };

        [HttpGet]

        //IEnumerable dediğimiz yapı liste içinde dönmemizi sağlar.
        //ActionResult ise dönüş tipidir. IActionResult'dan türetilmiştir. hata durumlarını kontrol etmemizi sağlar.
        public ActionResult<List<VideoGame>> GetVideoGames()
        {
            return Ok(videoGames);
        }

        public ActionResult<VideoGame> GetVideoGameById(int id) 
        {
            var videoGame = videoGames.FirstOrDefault(v => v.Id == id);
            if (videoGame == null)
            {
                return NotFound();
            }
            return Ok(videoGame);
        }
    }
}
