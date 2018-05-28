using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokeMart.Web.Service;

namespace PokeMart.Web.Controllers
{
    [Route("api/cardprice")]
    public class CardPriceController : Controller
    {
        private readonly CardPriceService _cardPriceService;

        public CardPriceController()
        {
            _cardPriceService = new CardPriceService();
        }
        [Route("card/{cardId}")]
        public async Task<IActionResult> GetSets(string cardId)
        {
            return Json(await _cardPriceService.For(cardId));
        }
    }
}