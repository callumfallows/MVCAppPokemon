using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeMart.Web.Service;

namespace PokeMart.Web.Controllers
{
    [Route("api/carddatabase")]
    public class CardDatabaseController : Controller
    {
        private readonly CardDatabaseService _cardDatabaseService;

        public CardDatabaseController()
        {
            _cardDatabaseService = new CardDatabaseService();
        }
        [Route("sets")]
        public async Task<IActionResult> GetSets()
        {
            return Json(await _cardDatabaseService.Sets());
        }

        [Route("sets/{id}")]
        public async Task<IActionResult> GetSets(string id)
        {
            return Json(await _cardDatabaseService.Sets(id));
        }

        [Route("sets/{id}/cards")]
        public async Task<IActionResult> GetSetCards(string id)
        {
            return Json(await _cardDatabaseService.Cards(id));
        }
    }
}