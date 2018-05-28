namespace PokeMart.Web.Types
{
    public class ExternalCardListing
    {
        public ExternalCardListing(string url, decimal price, bool inStock)
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