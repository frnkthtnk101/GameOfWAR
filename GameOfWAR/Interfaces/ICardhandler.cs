using GameOfWAR.POCOS;
using System.Collections.Generic;

namespace GameOfWAR.Interfaces
{
    public interface ICardhandler
    {
        void ShuffleCards();
        void Split(int numOfPlayers = 2);
        IEnumerable<Card> GetPlayerDeck(int Player);
    }
}
