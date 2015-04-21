﻿using NUnit.Framework;

namespace TextSearching.Tests
{
    [TestFixture]
    public class FixedStringSearchExtensionTest
    {
        [TestCase]
        public void Should_Find_All_Occurances()
        {
            // arrange
            var text = "cacgtatatatgcgttataat";
            var pattern = "tata";

            // act
            var occurances = text.NaiveSearch(pattern);

            // assert
            Assert.IsNotNull(occurances);
            Assert.AreEqual(3, occurances.Length);
            Assert.AreEqual(4, occurances[0]);
            Assert.AreEqual(6, occurances[1]);
            Assert.AreEqual(15, occurances[2]);
        }
    }
}
