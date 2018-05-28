using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PokeMart.Web.Types;

namespace PokeMart.Web.Data
{
    public class PokemonTcgApiRepository
    {
        private readonly HttpClient _httpClient;

        public PokemonTcgApiRepository()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<CardSet>> Sets()
        {
            var responseStr = await _httpClient.GetStringAsync("https://api.pokemontcg.io/v1/sets");
            var response = JsonConvert.DeserializeObject<CardSetsJsonProxy>(responseStr);

            if (response.sets.Count == 0)
                return new List<CardSet>();

            return response.sets.Select(MapCardSet).ToList();
        }

        public async Task<List<Card>> Cards(string setCode)
        {
            var responseStr = await _httpClient.GetStringAsync("https://api.pokemontcg.io/v1/cards?setCode=" + setCode);
            var response = JsonConvert.DeserializeObject<CardsJsonProxy>(responseStr);

            if (response.cards.Count == 0)
                return new List<Card>();

            return response.cards.Select(MapCard).ToList();
        }

        public async Task<Card> Card(string cardId)
        {
            var responseStr = await _httpClient.GetStringAsync("https://api.pokemontcg.io/v1/cards/" + cardId);
            var response = JsonConvert.DeserializeObject<CardJsonProxy>(responseStr);

            if (response.card == null)
                return null;

            return MapCard(response.card);
        }

        private Card MapCard(CardInnerJsonProxy c)
        {
            var attacks = c.attacks.Select(a => new Attack(a.cost, a.name, a.text, a.damage, a.convertedEnergyCost)).ToArray();
            var ability = new Ability(c.ability.name, c.ability.text, c.ability.type);
            var weakness = c.weaknesses.Select(w => new Weakness(w.type, w.value)).ToArray();
            var resistance = c.resistances.Select(r => new Resistance(r.type, r.value)).ToArray();
            var text = string.Join("",c.text);
            return new Card(c.id, c.name,c.nationalPokedexNumber,c.hp,c.imageUrl,c.imageUrlHiRes,c.types,c.number,c.subtype,c.supertype,attacks,text, ability, weakness, resistance, c.retreatCost, c.convertedRetreatCost, c.artist, c.set, c.setCode, c.rarity);
        }

        public async Task<CardSet> Sets(string id)
        {
            var responseStr = await _httpClient.GetStringAsync("https://api.pokemontcg.io/v1/sets/" + id);
            var response = JsonConvert.DeserializeObject<CardSetJsonProxy>(responseStr);

            if (response.set == null)
                return null;

            return MapCardSet(response.set);
        }

        private static CardSet MapCardSet(CardSetInnerJsonProxy s)
        {
            return new CardSet(s.code, s.ptcgoCode, s.name, s.series, s.totalCards, s.standardLegal, s.expandedLegal, DateTime.ParseExact(s.releaseDate, "d", CultureInfo.InvariantCulture), s.symbolUrl, s.logoUrl);
        }

        private class CardsJsonProxy
        {
            public List<CardInnerJsonProxy> cards { get; set; }
        }

        private class CardJsonProxy
        {
            public CardInnerJsonProxy card { get; set; }
        }

        private class CardInnerJsonProxy
        {
            public string id { get; set; }
            public string name { get; set; }
            public int nationalPokedexNumber { get; set; }
            public string hp { get; set; }
            public string imageUrl { get; set; }
            public string imageUrlHiRes { get; set; }
            public string[] types { get; set; } = new string[0];
            public string number { get; set; }
            public string subtype { get; set; }
            public string supertype { get; set; }
            public AttackJsonProxy[] attacks { get; set; } = new AttackJsonProxy[0];
            public string[] text { get; set; } = new string[0];
            public AbilityJsonProxy ability { get; set; } = new AbilityJsonProxy();
            public WeaknessJsonProxy[] weaknesses { get; set; } = new WeaknessJsonProxy[0];
            public ResistanceJsonProxy[] resistances { get; set; } = new ResistanceJsonProxy[0];
            public string[] retreatCost { get; set; } = new string[0];
            public int convertedRetreatCost { get; set; }
            public string artist { get; set; }
            public string set { get; set; }
            public string setCode { get; set; }
            public string rarity { get; set; }
        }

        private class AbilityJsonProxy
        {
            public string name { get; set; }
            public string text { get; set; }
            public string type { get; set; }
        }

        private class AttackJsonProxy
        {
            public string[] cost { get; set; } = new string[0];
            public string name { get; set; }
            public string text { get; set; }
            public string damage { get; set; }
            public int convertedEnergyCost { get; set; }
        }

        private class WeaknessJsonProxy
        {
            public string type { get; set; }
            public string value { get; set; }
        }

        private class ResistanceJsonProxy
        {
            public string type { get; set; }
            public string value { get; set; }
        }


        private class CardSetsJsonProxy
        {
            public List<CardSetInnerJsonProxy> sets { get; set; } = new List<CardSetInnerJsonProxy>();
        }

        private class CardSetJsonProxy
        {
            public CardSetInnerJsonProxy set { get; set; }
        }

        private class CardSetInnerJsonProxy
        {
            public string code { get; set; }
            public string ptcgoCode { get; set; }
            public string name { get; set; }
            public string series { get; set; }
            public int totalCards { get; set; }
            public bool standardLegal { get; set; }
            public bool expandedLegal { get; set; }
            public string releaseDate { get; set; }
            public string symbolUrl { get; set; }
            public string logoUrl { get; set; }
        }
    }
}