using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PokeMart.Web.ApiTypes;
using PokeMart.Web.Data;
using PokeMart.Web.Types;

namespace PokeMart.Web.Service
{
    public class CardDatabaseService
    {
        private readonly PokemonTcgApiRepository _database;

        public CardDatabaseService()
        {
            _database = new PokemonTcgApiRepository();
        }
        public async Task<ApiResponse<List<CardSetResponse>>> Sets()
        {
            var cardSets = await _database.Sets();
            return ApiResponse<List<CardSetResponse>>.Success(cardSets.Select(MapCardSet).ToList());
        }

        public async Task<ApiResponse<List<CardResponse>>> Cards(string setCode)
        {
            var cards = await _database.Cards(setCode);
            return ApiResponse<List<CardResponse>>.Success(cards.Select(MapCard).ToList());
        }

        public async Task<ApiResponse<CardSetResponse>> Sets(string id)
        {
            var cardSet = await _database.Sets(id);
            if (cardSet == null)
                return ApiResponse<CardSetResponse>.Fail("Not Found");
            return ApiResponse<CardSetResponse>.Success(MapCardSet(cardSet));
        }

        private CardResponse MapCard(Card c)
        {
            var attacks = c.Attacks.Select(a => new CardResponse.AttackResponse(a.Cost, a.Name, a.Text, a.Damage, a.ConvertedEnergyCost)).ToArray();
            var ability = new CardResponse.AbilityResponse(c.Ability.Name, c.Ability.Text, c.Ability.Type);
            var weakness = c.Weaknesses.Select(w => new CardResponse.WeaknessResponse(w.Type, w.Value)).ToArray();
            var text = string.Join("", c.Text);
            var resistances = c.Resistances.Select(r => new CardResponse.ResistanceResponse(r.Type,r.Value)).ToArray();
            return new CardResponse(c.Id, c.Name, c.NationalPokedexNumber, c.Hp, c.ImageUrl, c.ImageUrlHiRes, c.Types, c.Number, c.Subtype, c.Supertype, attacks, text, ability, weakness, resistances, c.RetreatCost, c.ConvertedRetreatCost, c.Artist, c.Set, c.SetCode, c.Rarity);
        }

        private static CardSetResponse MapCardSet(CardSet s)
        {
            return new CardSetResponse(s.Code, s.PtcgoCode, s.Name, s.Series, s.TotalCards, s.StandardLegal, s.ExpandedLegal, s.ReleaseDate, s.SymbolUrl, s.LogoUrl);
        }
    }
}