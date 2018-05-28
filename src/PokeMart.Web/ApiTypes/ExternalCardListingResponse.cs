namespace PokeMart.Web.ApiTypes
{
    public class ExternalCardListingResponse
    {
        public ExternalCardListingResponse(string url, decimal price, bool inStock)
        {
            Url = url;
            Price = price;
            InStock = inStock;
        }

        public string Url { get; }
        public decimal Price { get; }
        public bool InStock { get; }
    }
}