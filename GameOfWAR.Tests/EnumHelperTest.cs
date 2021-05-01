using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GameOfWAR.Enums;
using GameOfWAR.Helper;
using System.Collections.Generic;

namespace GameOfWAR.Tests
{
    [TestClass]
    public class EnumHelperTest : TestHelper
    {
        [TestMethod]
        public void ShouldGibeAllEnums()
        {
            //Arrange
            var correctEnums = new HashSet<CardFace>(GetEnumList<CardFace>());
            //Test
            var givenEnums = new HashSet<CardFace>(EnumHelper.GetEnumList<CardFace>());
            correctEnums.ExceptWith(givenEnums);
            var correct = correctEnums.Count == 0;
            //Assert
            Assert.IsTrue(correct);
            //Clean up - none
        }
    }
}
