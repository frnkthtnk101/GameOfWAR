using GameOfWAR.Interfaces;
using GameOfWAR.Logic;
using GameOfWAR.POCOS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfWAR
{
    class Program
    {
        static void Main(string[] args)
        {
            ICardhandler cardhandler = new DeckWithJokers();
            IWarRules warRules = new WarRules();
            PlayWar(cardhandler, warRules);
        }

        static void PlayWar(ICardhandler cardhandler, IWarRules warRules)
        {
            cardhandler.Split();
            var playerOne = new Queue<Card>(cardhandler.GetPlayerDeck(0));
            var playerTwo = new Queue<Card>(cardhandler.GetPlayerDeck(1));
            while(!warRules.GameOver(playerOne,playerTwo))
            {
                var outcomeOfBatte = warRules.DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                var spoilsOfWar = new List<Card>();
                DecideWhoToGiveSpoilsTo(outcomeOfBatte, playerOne, playerTwo, spoilsOfWar, warRules);
            } 
        }

        private static void DecideWhoToGiveSpoilsTo(int outcomeOfBatte, Queue<Card> playerOne, Queue<Card> playerTwo, List<Card> spoilsOfWar, IWarRules warRules)
        {
            switch (outcomeOfBatte)
            {
                case -1:
                    spoilsOfWar.Add(playerOne.Dequeue());
                    spoilsOfWar.Add(playerTwo.Dequeue());
                    GiveSpoilsToPlayer(playerOne, spoilsOfWar);
                    break;
                case 1:
                    spoilsOfWar.Add(playerOne.Dequeue());
                    spoilsOfWar.Add(playerTwo.Dequeue());
                    GiveSpoilsToPlayer(playerTwo, spoilsOfWar);
                    break;
                default:
                    for (int i = 0; i < 3; i++)
                    {
                        if (playerOne.Count > 1) spoilsOfWar.Add(playerOne.Dequeue());
                        if (playerTwo.Count > 1) spoilsOfWar.Add(playerTwo.Dequeue());
                    }
                    outcomeOfBatte = warRules.DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                    DecideWhoToGiveSpoilsTo(outcomeOfBatte, playerOne, playerTwo, spoilsOfWar, warRules);
                    break;
            }
        }

        static void GiveSpoilsToPlayer(Queue<Card> player, List<Card> cards)
        {
            foreach (var card in cards)
            {
                player.Enqueue(card);
            }
        }
    }
}
