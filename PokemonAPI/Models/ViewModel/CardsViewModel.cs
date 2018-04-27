using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PokemonTcgSdk;

namespace PokemonAPI.Models.ViewModel
{
    public class CardsViewModel
    {

        public Card Card { get; set; }
        public List<Pokemon> Cards { get; set; }
        public Pokemon Pokemon { get; set; }

        public CardsViewModel(Pokemon pokemon)
        {
            Pokemon = pokemon;
        }

        public CardsViewModel(Card card)
        {
            Card = card;
        }

    }
}