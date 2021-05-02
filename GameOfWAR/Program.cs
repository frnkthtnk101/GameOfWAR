using GameOfWAR.Helper;
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
        static IWarRules warRules;
        static ICardhandler cardhandler;
        static IWriter writer;

        static void Main(string[] args)
        {
            cardhandler = new DeckWithJokers();
            warRules = new WarRules();
            writer = new ScreenHelper();
            PlayWar();
        }

        static void PlayWar()
        {
            var play = true;
            while(play)
            {
                cardhandler.ShuffleCards();
                cardhandler.Split();
                var playerOne = new Queue<Card>(cardhandler.GetPlayerDeck(0));
                var playerTwo = new Queue<Card>(cardhandler.GetPlayerDeck(1));
                var counter = 1;
                while (!warRules.GameOver(playerOne, playerTwo))
                {
                    Console.WriteLine($"Round {counter}... FIGHT");
                    var spoilsOfWar = new List<Card>();
                    var winnerOfbattle = warRules.DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                    warRules.Fight(playerOne, playerTwo, winnerOfbattle, spoilsOfWar, writer);
                    counter++;
                    writer.Read("Press Enter to play the next round");
                }
                DetermineWinner(playerOne, playerTwo);
                play = playAgain();
            }

        }

        static bool playAgain()
        {
            var invalidResponse = true;
            var response = false;
            do
            {
                var input = writer.Read("press y and enter to play again, or press n and enter to quit.");
                if(input == "y" || input == "n")
                {
                    invalidResponse = false;
                    response = input == "y" ? true : false;
                }
            } while (invalidResponse);
            return response;
        }

        static void DetermineWinner(Queue<Card> playerOne, Queue<Card> playerTwo)
        {
            if (warRules.WhoIsWinner(playerOne, playerTwo) == 1)
                writer.Write("player 1 won!");
            else
                writer.Write("player 2 won!");
        }
    }
}
