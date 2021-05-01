using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfWAR.Interfaces;
using GameOfWAR.POCOS;
using GameOfWAR.Enums;
using GameOfWAR.Helper;

namespace GameOfWAR.Logic
{
    public class DeckWithJokers : ICardhandler
    {
        List<Card> _DeckOfCards;
        int _cardDivider;
        readonly int _NumberOfCardsInDeck = 54;
        public DeckWithJokers()
        {
            _DeckOfCards = new List<Card>(_NumberOfCardsInDeck)
            {
                new Card()
                {
                    Face = CardFace.Joker,
                    Value = CardValues.Joker
                }
            };
            var facesInDeck = EnumHelper.GetEnumList<CardFace>()
                .Where(x => x != CardFace.Joker);
            var valuesInDeck = EnumHelper.GetEnumList<CardValues>()
                .Where(x => x != CardValues.Joker);
            foreach (var face in facesInDeck)
                foreach (var value in valuesInDeck)
                    _DeckOfCards.Add(new Card()
                    {
                        Face = face,
                        Value = value
                    });
            _cardDivider = 0;

        }
        public IEnumerable<Card> GetPlayerDeck(int player)
        {

            var groupToGet = 0;
            if (player > 0) groupToGet = player;
            int low = _cardDivider * groupToGet;
            int high = _cardDivider * groupToGet + 1;
            var cards = _DeckOfCards.GetRange(low, high);
            return cards;
        }

        public void ShuffleCards()
        {
            var indexScrambler = new Random();
            for(int i = 0; i < _NumberOfCardsInDeck; i++)
            {
                var randomIndex = indexScrambler.Next(0, _NumberOfCardsInDeck - 1);
                var tempvalue = _DeckOfCards[randomIndex];
                _DeckOfCards[randomIndex] = _DeckOfCards[i];
                _DeckOfCards[i] = tempvalue;
            }
        }


        public void Split(int numOfPlayers = 2)
        {
            throw new NotImplementedException();
        }
    }
}
