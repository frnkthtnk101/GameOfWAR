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

        public void Fight(Queue<Card> playerOne, Queue<Card> playerTwo, int winnerOfbattle, List<Card> spoilsOfWar)
        {
            switch (winnerOfbattle)
            {
                case -1:
                case 1:
                    spoilsOfWar.Add(playerOne.Dequeue());
                    spoilsOfWar.Add(playerTwo.Dequeue());
                    if(winnerOfbattle == -1) GiveSpoilsToPlayer(playerOne, spoilsOfWar);
                    else GiveSpoilsToPlayer(playerTwo, spoilsOfWar);
                    break;
                default:
                    for (int i = 0; i < 3; i++)
                    {
                        if (playerOne.Count > 1) spoilsOfWar.Add(playerOne.Dequeue());
                        if (playerTwo.Count > 1) spoilsOfWar.Add(playerTwo.Dequeue());
                    }
                    winnerOfbattle = DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                    Fight(playerOne, playerTwo, winnerOfbattle, spoilsOfWar);
                    break;
            }
        }

        private void GiveSpoilsToPlayer(Queue<Card> player, List<Card> spoilsOfWar)
        {
            foreach (var card in spoilsOfWar)
            {
                player.Enqueue(card);
            }
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
