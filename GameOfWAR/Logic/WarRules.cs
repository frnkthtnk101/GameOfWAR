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
    public class WarRules : IWarRules
    {
        public int DetermineWinnerOfBattle(Card playerOneCard, Card playerTwoCard)
        {
            //0  = WAR
            //-1 = player one
            //1  = player two
            var determinationOfBattle = 0;
            if (playerOneCard.Value > playerTwoCard.Value) determinationOfBattle = -1;
            else if (playerOneCard.Value < playerTwoCard.Value) determinationOfBattle = 1;
            return determinationOfBattle;
        }

        public bool GameOver(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo)
        {
            return playerOne.Count() == 0 || playerOne.Count() == 0;
        }

        public int WhoIsWinner(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo)
        {
            int winner = 0;
            if (playerOne.Count() == 0) winner = 1;
            return winner;
        }
    }
}
