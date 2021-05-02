using GameOfWAR.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR.Helper
{
    public static class ShuffleHelper
    {
        public static void ShuffleCards(List<Card> deckOfCards)
        {
            var indexScrambler = new Random();
            var numberOfCardsInDeck = deckOfCards.Count();
            for (int i = 0; i < numberOfCardsInDeck; i++)
            {
                var randomIndex = indexScrambler.Next(0, numberOfCardsInDeck - 1);
                var tempvalue = deckOfCards[randomIndex];
                deckOfCards[randomIndex] = deckOfCards[i];
                deckOfCards[i] = tempvalue;
            }
        }
    }
}
