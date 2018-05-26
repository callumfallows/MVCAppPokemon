namespace PokeMart.Web.Types
{
    public class Card
    {
        public Card(string id, string name, int nationalPokedexNumber, string hp, string imageUrl, string imageUrlHiRes, string[] types, string number, string subtype, string supertype, Attack[] attacks, string text, Ability ability, Weakness[] weaknesses, Resistance[] resistances, string[] retreatCost, int convertedRetreatCost, string artist, string set, string setCode, string rarity)
        {
            Id = id;
            Name = name;
            NationalPokedexNumber = nationalPokedexNumber;
            Hp = hp;
            ImageUrl = imageUrl;
            ImageUrlHiRes = imageUrlHiRes;
            Types = types;
            Number = number;
            Subtype = subtype;
            Supertype = supertype;
            Attacks = attacks;
            Text = text;
            Ability = ability;
            Weaknesses = weaknesses;
            Resistances = resistances;
            RetreatCost = retreatCost;
            ConvertedRetreatCost = convertedRetreatCost;
            Artist = artist;
            Set = set;
            SetCode = setCode;
            Rarity = rarity;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int NationalPokedexNumber { get; set; }
        public string Hp { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrlHiRes { get; set; }
        public string[] Types { get; set; }
        public string Number { get; set; }
        public string Subtype { get; set; }
        public string Supertype { get; set; }
        public Attack[] Attacks { get; set; }
        public string Text { get; set; }
        public Ability Ability { get; set; }
        public Weakness[] Weaknesses { get; set; }
        public Resistance[] Resistances { get; set; }
        public string[] RetreatCost { get; set; }
        public int ConvertedRetreatCost { get; set; }
        public string Artist { get; set; }
        public string Set { get; set; }
        public string SetCode { get; set; }
        public string Rarity { get; set; }
    }
}