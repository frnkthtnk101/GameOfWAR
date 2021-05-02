using System.Collections.Generic;
using System.Linq;
using GameOfWAR.Interfaces;
using GameOfWAR.POCOS;
using GameOfWAR.Enums;
using GameOfWAR.Helper;

namespace GameOfWAR.Logic
{
    public class WarRules : IWarRules
    {
        const int _WarFlag = 0;
        const int _PlayerOneFlag = -1;
        const int _PlayerTwoFlag = 1;

        public int DetermineWinnerOfBattle(Card playerOneCard, Card playerTwoCard)
        {
            var determinationOfBattle = _WarFlag;
            if (playerOneCard.Value > playerTwoCard.Value) 
                determinationOfBattle = _PlayerOneFlag;
            else if (playerOneCard.Value < playerTwoCard.Value) 
                determinationOfBattle = _PlayerTwoFlag;
            return determinationOfBattle;
        }

        public void Fight(Queue<Card> playerOne, Queue<Card> playerTwo, int winnerOfbattle, List<Card> spoilsOfWar, IWriter writer)
        {
            ShowPlayersCards(playerOne.Peek(), playerTwo.Peek(), writer);
            switch (winnerOfbattle)
            {
                case _PlayerOneFlag:
                case _PlayerTwoFlag:
                    spoilsOfWar.Add(playerOne.Dequeue());
                    spoilsOfWar.Add(playerTwo.Dequeue());
                    ShuffleHelper.ShuffleCards(spoilsOfWar);
                    if (winnerOfbattle == _PlayerOneFlag)
                    {
                        GiveSpoilsToPlayer(playerOne, spoilsOfWar);
                        writer.Write("Player one is victorious!");
                    }
                    else
                    {
                        GiveSpoilsToPlayer(playerTwo, spoilsOfWar);
                        writer.Write("Player two is victorious!");
                    }
                    break;
                case _WarFlag:
                    writer.Write("WAAARRR!");
                    for (int i = 0; i < 3; i++)
                    {
                        if (playerOne.Count > 1) spoilsOfWar.Add(playerOne.Dequeue());
                        if (playerTwo.Count > 1) spoilsOfWar.Add(playerTwo.Dequeue());
                    }
                    winnerOfbattle = DetermineWinnerOfBattle(playerOne.Peek(), playerTwo.Peek());
                    Fight(playerOne, playerTwo, winnerOfbattle, spoilsOfWar, writer);
                    break;
                default:
                    break;
            }
        }

        public bool GameOver(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo)
        {
            return playerOne.Count() == 0 || playerTwo.Count() == 0;
        }

        public int WhoIsWinner(IEnumerable<Card> playerOne, IEnumerable<Card> playerTwo)
        {
            int winner = _PlayerOneFlag;
            if (playerOne.Count() == 0) winner = _PlayerTwoFlag;
            return winner;
        }
        void ShowPlayersCards(Card playerOneCard, Card playerTwoCard, IWriter writer)
        {
            var playerOneCardString = ConvertCardToString(playerOneCard);
            var playerTwoCardString = ConvertCardToString(playerTwoCard);
            writer.Write($"player 1: {playerOneCardString} player 2: {playerTwoCardString}");
        }

        string ConvertCardToString(Card card)
        {
            var finalvalue = "[";
            if (card.Face == CardFace.Joker)
                finalvalue += "JOKER";
            else
                finalvalue += $"{card.Face} {card.Value}";
            finalvalue += "]";
            return finalvalue;
        }

        void GiveSpoilsToPlayer(Queue<Card> player, List<Card> spoilsOfWar)
        {
            foreach (var card in spoilsOfWar)
            {
                player.Enqueue(card);
            }
        }
    }
}
