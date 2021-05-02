using GameOfWAR.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR.Interfaces
{
    public interface IWarRules
    {
        
        bool GameOver(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo);
        int DetermineWinnerOfBattle(Card playerOneCard, Card playerTwoCard);
        int WhoIsWinner(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo);
        void Fight(Queue<Card> playerOne, Queue<Card> playerTwo, int winnerOfbattle, List<Card> spoilsOfWar, IWriter writer);
    }
}
