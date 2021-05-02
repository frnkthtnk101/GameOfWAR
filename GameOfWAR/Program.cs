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
            var counter = 1;
            while(!warRules.GameOver(playerOne,playerTwo))
            {
                Console.WriteLine($"Round {counter}... FIGHT");
                var spoilsOfWar = new List<Card>();
                var winnerOfbattle = warRules.DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                warRules.Fight(playerOne, playerTwo, winnerOfbattle, spoilsOfWar);
            } 
        }
    }
}
