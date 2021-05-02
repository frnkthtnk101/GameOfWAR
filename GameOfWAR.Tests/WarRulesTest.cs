using GameOfWAR.Enums;
using GameOfWAR.Interfaces;
using GameOfWAR.Logic;
using GameOfWAR.POCOS;
using GameOfWAR.Tests.Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfWAR.Tests
{
    [TestClass]
    public class WarRulesTest
    {
        IWarRules _WarRules;
        int _PlayerOneWon, _PlayerTwoWon, _War;
        IWriter _Writer;
        public WarRulesTest()
        {
            _War = 0;
            _PlayerOneWon = -1;
            _PlayerTwoWon = 1;
            _Writer = new FakeWriter();
        }
        [TestMethod]
        public void ShouldMakePlayerOneWinner()
        {
            //Arrange
            var playerOneCard = new Card
            {
                Face = CardFace.Joker,
                Value = CardValues.Joker
            };
            var playerTwoCard = new Card
            {
                Face = CardFace.Clubs,
                Value = CardValues.Two
            };
            _WarRules = new WarRules();
            //test
            var givenResult = _WarRules.DetermineWinnerOfBattle(playerOneCard, playerTwoCard);
            var correct = givenResult == _PlayerOneWon;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldMakePlayertwoWinner()
        {
            //Arrange
            var playerTwoCard = new Card
            {
                Face = CardFace.Joker,
                Value = CardValues.Joker
            };
            var playerOneCard = new Card
            {
                Face = CardFace.Clubs,
                Value = CardValues.Two
            };
            _WarRules = new WarRules();
            //test
            var givenResult = _WarRules.DetermineWinnerOfBattle(playerOneCard, playerTwoCard);
            var correct = givenResult == _PlayerTwoWon;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldDetermineWar()
        {
            //Arrange
            var playerTwoCard = new Card
            {
                Face = CardFace.Clubs,
                Value = CardValues.Two
            };
            var playerOneCard = new Card
            {
                Face = CardFace.Clubs,
                Value = CardValues.Two
            };
            _WarRules = new WarRules();
            //test
            var givenResult = _WarRules.DetermineWinnerOfBattle(playerOneCard, playerTwoCard);
            var correct = givenResult == _War;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldGiveSpoilsOfWarToPlayerOne()
        {
            //Arrange
            var spoilsOfWar = new List<Card>();
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerOne.Enqueue(new Card() { Face = CardFace.Joker });
            playerTwo.Enqueue(new Card() { Face = CardFace.Diamonds });
            spoilsOfWar.Add(new Card());
            _WarRules = new WarRules();
            //test
            _WarRules.Fight(playerOne, playerTwo, _PlayerOneWon, spoilsOfWar, _Writer);
            //Assert
            var playerOneCardCount = playerOne.Count() == 3;
            var playerTwoCardCount = playerTwo.Count() == 0;
            var correct = playerOneCardCount && playerTwoCardCount;
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldGiveSpoilsOfWarToPlayerTwo()
        {
            //Arrange
            var spoilsOfWar = new List<Card>();
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerOne.Enqueue(new Card() { Face = CardFace.Joker });
            playerTwo.Enqueue(new Card() { Face = CardFace.Diamonds });
            spoilsOfWar.Add(new Card());
            _WarRules = new WarRules();
            //test
            _WarRules.Fight(playerOne, playerTwo, _PlayerTwoWon, spoilsOfWar, _Writer);
            //Assert
            var playerOneCardCount = playerOne.Count() == 0;
            var playerTwoCardCount = playerTwo.Count() == 3;
            var correct = playerOneCardCount && playerTwoCardCount;
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldGiveSpoilsOfWarToPlayerTwoAfterWar()
        {
            //Arrange
            var spoilsOfWar = new List<Card>();
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerOne.Enqueue(new Card());
            playerTwo.Enqueue(new Card() { Value = CardValues.Joker });
            playerTwo.Enqueue(new Card() { Value = CardValues.Joker });
            playerTwo.Enqueue(new Card() { Value = CardValues.Joker });
            playerTwo.Enqueue(new Card() { Value = CardValues.Joker});
            _WarRules = new WarRules();
            //test
            _WarRules.Fight(playerOne, playerTwo, _War, spoilsOfWar, _Writer);
            //Assert
            var playerOneCardCount = playerOne.Count() == 0;
            var playerTwoCardCount = playerTwo.Count() == 5;
            var correct = playerOneCardCount && playerTwoCardCount;
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldGiveSpoilsOfWarToPlayerOneAfterWar()
        {
            //Arrange
            var spoilsOfWar = new List<Card>();
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerTwo.Enqueue(new Card());
            playerOne.Enqueue(new Card() { Value = CardValues.Joker });
            playerOne.Enqueue(new Card() { Value = CardValues.Joker });
            playerOne.Enqueue(new Card() { Value = CardValues.Joker });
            playerOne.Enqueue(new Card() { Value = CardValues.Joker });
            _WarRules = new WarRules();
            //test
            _WarRules.Fight(playerOne, playerTwo, _War, spoilsOfWar, _Writer);
            //Assert
            var playerOneCardCount = playerOne.Count() == 5;
            var playerTwoCardCount = playerTwo.Count() == 0;
            var correct = playerOneCardCount && playerTwoCardCount;
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldSayGameOverBecauseOfPlayerOne()
        {
            //Arrange
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerTwo.Enqueue(new Card());
            _WarRules = new WarRules();
            //test
            var correct = _WarRules.GameOver(playerOne, playerTwo);
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldSayGameOverBecauseOfPlayerTwo()
        {
            //Arrange
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerOne.Enqueue(new Card());
            _WarRules = new WarRules();
            //test
            var correct = _WarRules.GameOver(playerOne, playerTwo);
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldSayPlayerOneWonTheGame()
        {
            //Arrange
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerOne.Enqueue(new Card());
            _WarRules = new WarRules();
            //test
            var correct = _WarRules.WhoIsWinner(playerOne, playerTwo) == _PlayerOneWon;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldSayPlayerTwoWonTheGame()
        {
            //Arrange
            Queue<Card> playerOne = new Queue<Card>();
            Queue<Card> playerTwo = new Queue<Card>();
            playerTwo.Enqueue(new Card());
            _WarRules = new WarRules();
            //test
            var correct = _WarRules.WhoIsWinner(playerOne, playerTwo) == _PlayerTwoWon;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
    }
}
