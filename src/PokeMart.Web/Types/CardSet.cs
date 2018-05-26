using System;

namespace PokeMart.Web.Types
{
    public class CardSet
    {
        public CardSet(string code, string ptcgoCode, string name, string series, int totalCards, bool standardLegal, bool expandedLegal, DateTime releaseDate, string symbolUrl, string logoUrl)
        {
            Code = code;
            PtcgoCode = ptcgoCode;
            Name = name;
            Series = series;
            TotalCards = totalCards;
            StandardLegal = standardLegal;
            ExpandedLegal = expandedLegal;
            ReleaseDate = releaseDate;
            SymbolUrl = symbolUrl;
            LogoUrl = logoUrl;
        }

        public string Code { get; }
        public string PtcgoCode { get; }
        public string Name { get; }
        public string Series { get; }
        public int TotalCards { get; }
        public bool StandardLegal { get; }
        public bool ExpandedLegal { get; }
        public DateTime ReleaseDate { get; }
        public string SymbolUrl { get; }
        public string LogoUrl { get; }
    }
}