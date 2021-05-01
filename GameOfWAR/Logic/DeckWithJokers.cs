using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfWAR.Interfaces;
using GameOfWAR.POCOS;
using GameOfWAR.Enums;

namespace GameOfWAR.Logic
{
    public class DeckWithJokers : ICardhandler
    {
        List<Card> DeckOfCards;
        public DeckWithJokers()
        {
            DeckOfCards = new List<Card>(54)
            {
                new Card()
                {
                    Face = CardFace.Joker,
                    Value = CardValues.Joker
                }
            };
            foreach(var face in Enc)
        }
        public void GetPlayerDeck(int Player)
        {
            throw new NotImplementedException();
        }

        public void ShuffleCards()
        {
            throw new NotImplementedException();
        }

        public void Split(int numOfPlayers = 2)
        {
            throw new NotImplementedException();
        }
    }
}
