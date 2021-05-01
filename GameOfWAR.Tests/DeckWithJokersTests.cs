using GameOfWAR.Logic;
using GameOfWAR.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;
using GameOfWAR.POCOS;

namespace GameOfWAR.Tests
{
    [TestClass]
    public class DeckWithJokersTests
    {
        DeckWithJokers _jokersTest;
        int _correctNumberOfCars;
        public DeckWithJokersTests()
        {
            _correctNumberOfCars = 54;
            
        }
        [TestMethod]
        public void ShouldCreateADeckOfFiftyFour()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            var numberOfCardsInDeck = _jokersTest.GetCards().Count;
            var hasCorrectNumberOfCards = numberOfCardsInDeck == _correctNumberOfCars;
            //Assert
            Assert.IsTrue(hasCorrectNumberOfCards);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldHaveTwoJokers()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            var numberOfJackInDeck = _jokersTest.GetCards().Where(x => x.Face == CardFace.Joker).Count();
            var hasCorrectNumberOfCards = 2 == numberOfJackInDeck;
            //Assert
            Assert.IsTrue(hasCorrectNumberOfCards);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldHavethirteenCardOfSpadesAndCorrectValues()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            bool correct = DoesDeckHaveCorrectCardsGroup(CardFace.Spades, _jokersTest.GetCards());
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldHavethirteenCardOfClubsAndCorrectValues()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            bool correct = DoesDeckHaveCorrectCardsGroup(CardFace.Clubs, _jokersTest.GetCards());
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldHavethirteenCardOfHeartsAndCorrectValues()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            bool correct = DoesDeckHaveCorrectCardsGroup(CardFace.Hearts, _jokersTest.GetCards());
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        [TestMethod]
        public void ShouldHavethirteenCardOfDiamondsAndCorrectValues()
        {
            //Arrange
            _jokersTest = new DeckWithJokers();
            //Test
            bool correct = DoesDeckHaveCorrectCardsGroup(CardFace.Diamonds, _jokersTest.GetCards());
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
        private bool DoesDeckHaveCorrectCardsGroup(CardFace face, List<Card> cards)
        {
            bool istrue = false;
            var valueGroup = GetEnumList<CardValues>().Where(x => x != CardValues.Joker);
            foreach(var value in valueGroup)
            {
                istrue = cards.Where(x => x.Face == face && x.Value == value).Count() == 1;
                if (!istrue) break;
            }
            return istrue;

        }
        IEnumerable<T> GetEnumList<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>();
        }
    }
}
