using System;
using System.Collections.Generic;
using System.Linq;
using GameOfWAR.Interfaces;
using GameOfWAR.POCOS;
using GameOfWAR.Enums;
using GameOfWAR.Helper;

namespace GameOfWAR.Logic
{
    public class DeckWithJokers : ICardhandler
    {
        readonly int _numberOfCardsInDeck = 54;
        List<Card> _deckOfCards;
        int _cardDivider;
        bool _lastPlayerGetsAnExtraCard; 

        public DeckWithJokers()
        {
            _deckOfCards = new List<Card>(_numberOfCardsInDeck)
            {
                new Card()
                {
                    Face = CardFace.Joker,
                    Value = CardValues.Joker
                },
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
                    _deckOfCards.Add(new Card()
                    {
                        Face = face,
                        Value = value
                    });
            

        }

        public IEnumerable<Card> GetPlayerDeck(int player)
        {

            var groupToGet = 0;
            if (player > 0) groupToGet = player;
            int startingIndex = groupToGet * _cardDivider;
            int numberToGet = _cardDivider;
            var handLastCard = startingIndex + numberToGet + 1 == _numberOfCardsInDeck - 1 && _lastPlayerGetsAnExtraCard;
            if (handLastCard) numberToGet++;
            var cards = _deckOfCards.GetRange(startingIndex, numberToGet);
            return cards;
        }

        public void ShuffleCards()
        {
            var indexScrambler = new Random();
            for(int i = 0; i < _numberOfCardsInDeck; i++)
            {
                var randomIndex = indexScrambler.Next(0, _numberOfCardsInDeck - 1);
                var tempvalue = _deckOfCards[randomIndex];
                _deckOfCards[randomIndex] = _deckOfCards[i];
                _deckOfCards[i] = tempvalue;
            }
        }

        public void Split(int numOfPlayers = 2)
        {
            _cardDivider = _numberOfCardsInDeck / numOfPlayers;
            if (_numberOfCardsInDeck % numOfPlayers  > 0) _lastPlayerGetsAnExtraCard = true;
        }
        public List<Card> GetCards() => _deckOfCards;
    }
}
