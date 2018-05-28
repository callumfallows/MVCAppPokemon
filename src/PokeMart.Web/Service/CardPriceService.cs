using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PokeMart.Web.ApiTypes;
using PokeMart.Web.Data;
using PokeMart.Web.Types;

namespace PokeMart.Web.Service
{
    public class CardPriceService
    {
        private readonly PokemonTcgApiRepository _cards;
        private readonly MagicMadHousePriceRepository _prices;

        public CardPriceService()
        {
            _cards = new PokemonTcgApiRepository();
            _prices = new MagicMadHousePriceRepository();
        }
        public async Task<ApiResponse<ExternalCardListingResponse>> For(string cardId)
        {
            var card = await _cards.Card(cardId);
            if(card == null)
                return ApiResponse<ExternalCardListingResponse>.Fail("Card not found.");

            var price = await _prices.For(card);
            if(price == null)
                return ApiResponse<ExternalCardListingResponse>.Fail("Price could not be found for card");

            return ApiResponse<ExternalCardListingResponse>.Success(new ExternalCardListingResponse(price.Url, price.Price, price.InStock));
        }
    }
}