using GameOfWAR.Helper;
using GameOfWAR.Interfaces;
using GameOfWAR.Logic;
using GameOfWAR.POCOS;
using System;
using System.Collections.Generic;

namespace GameOfWAR
{
    class Program
    {
        static IWarRules _WarRules;
        static ICardhandler _Cardhandler;
        static IWriter _Console;

        static void Main(string[] args)
        {
            _Cardhandler = new DeckWithJokers();
            _WarRules = new WarRules();
            _Console = new ScreenHelper();
            PlayWar();
        }

        static void PlayWar()
        {
            var playingAGame = true;
            while(playingAGame)
            {
                _Cardhandler.ShuffleCards();
                _Cardhandler.Split();
                var playerOne = new Queue<Card>(_Cardhandler.GetPlayerDeck(0));
                var playerTwo = new Queue<Card>(_Cardhandler.GetPlayerDeck(1));
                var counter = 1;
                while (!_WarRules.GameOver(playerOne, playerTwo))
                {
                    _Console.Read($"Round {counter}... FIGHT");
                    var spoilsOfWar = new List<Card>();
                    //The Fight method is a recursive method, so I decided to kickstart u in the main program.
                    var winnerOfbattle = _WarRules.DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                    _WarRules.Fight(playerOne, playerTwo, winnerOfbattle, spoilsOfWar, _Console);
                    counter++;
                    _Console.Read("Press Enter to play the next round");
                }
                DetermineWinner(playerOne, playerTwo);
                playingAGame = playAgain();
            }

        }

        static bool playAgain()
        {
            var invalidResponse = true;
            var response = false;
            do
            {
                var input = _Console.Read("press y and enter to play again, or press n and enter to quit.").ToLower();
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
            if (_WarRules.WhoIsWinner(playerOne, playerTwo) == -1)
                _Console.Write("player 1 won!");
            else
                _Console.Write("player 2 won!");
        }
    }
}
