using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using HtmlAgilityPack;
using PokeMart.Web.Service;
using PokeMart.Web.Types;

namespace PokeMart.Web.Data
{
    public class MagicMadHousePriceRepository
    {
        private const string MagicMadHouseUrl = "https://www.magicmadhouse.co.uk";
        private readonly HttpClient _httpClient;

        public MagicMadHousePriceRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ExternalCardListing> For(Card card)
        {
            var queryStr = $"{card.Set} {card.Name}";
            queryStr = queryStr.Replace(" ", "-");
            queryStr = new Regex("[^a-zA-Z0-9 -]").Replace(queryStr, "");
            var responseStr = await _httpClient.GetStringAsync("https://www.magicmadhouse.co.uk/search/" + queryStr);
            var html = new HtmlDocument();
            html.LoadHtml(responseStr);
            var priceSpan = html.DocumentNode.Descendants("span")
                .Where(n => n.Attributes["class"]?.Value == "GBP")
                .Skip(2)
                .FirstOrDefault();
            if (priceSpan != null)
            {
                var urlNode = html.DocumentNode.Descendants("a")
                    .Where(n => n.Attributes["class"]?.Value == "infclick")
                    .First();
                var stockNode = html.DocumentNode.Descendants("span")
                    .Where(n => (n.Attributes["class"]?.Value??"").StartsWith("stock-message"))
                    .First();
                var inStock = stockNode.InnerText.Contains("In Stock");
                var url = MagicMadHouseUrl + urlNode.Attributes["href"].Value;
                var price = decimal.Parse(priceSpan.InnerText.TrimStart('£'));
                return new ExternalCardListing(url, price, inStock);
            }
            return null;
        }
    }
}