namespace PokeMart.Web.ApiTypes
{
    public class CardResponse
    {
        public CardResponse(string id, string name, int nationalPokedexNumber, string hp, string imageUrl, string imageUrlHiRes, string[] types, string number, string subtype, string supertype, AttackResponse[] attacks, string text, AbilityResponse ability, WeaknessResponse[] weaknesses, ResistanceResponse[] resistances, string[] retreatCost, int convertedRetreatCost, string artist, string set, string setCode, string rarity)
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
        public AttackResponse[] Attacks { get; set; }
        public string Text { get; set; }
        public AbilityResponse Ability { get; set; }
        public WeaknessResponse[] Weaknesses { get; set; }
        public ResistanceResponse[] Resistances { get; set; }
        public string[] RetreatCost { get; set; }
        public int ConvertedRetreatCost { get; set; }
        public string Artist { get; set; }
        public string Set { get; set; }
        public string SetCode { get; set; }
        public string Rarity { get; set; }

        public class AbilityResponse
        {
            public AbilityResponse(string name, string text, string type)
            {
                Name = name;
                Text = text;
                Type = type;
            }

            public string Name { get; set; }
            public string Text { get; set; }
            public string Type { get; set; }
        }

        public class AttackResponse
        {
            public AttackResponse(string[] cost, string name, string text, string damage, int convertedEnergyCost)
            {
                Cost = cost;
                Name = name;
                Text = text;
                Damage = damage;
                ConvertedEnergyCost = convertedEnergyCost;
            }

            public string[] Cost { get; set; }
            public string Name { get; set; }
            public string Text { get; set; }
            public string Damage { get; set; }
            public int ConvertedEnergyCost { get; set; }
        }

        public class WeaknessResponse
        {
            public WeaknessResponse(string type, string value)
            {
                Type = type;
                Value = value;
            }

            public string Type { get; set; }
            public string Value { get; set; }
        }

        public class ResistanceResponse
        {
            public ResistanceResponse(string type, string value)
            {
                Type = type;
                Value = value;
            }

            public string Type { get; set; }
            public string Value { get; set; }
        }
    }
}