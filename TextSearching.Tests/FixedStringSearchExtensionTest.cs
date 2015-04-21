using NUnit.Framework;

namespace TextSearching.Tests
{
    [TestFixture]
    public class FixedStringSearchExtensionTest
    {
        private const string Text = "cacgtatatatgcgttataat";
        private const string Pattern = "tata";

        [TestCase]
        public void NaiveSearch_Should_Find_All_Occurances()
        {
            // arrange

            // act
            var occurances = Text.NaiveSearch(Pattern);

            // assert
            Assert.IsNotNull(occurances);
            Assert.AreEqual(3, occurances.Length);
            Assert.AreEqual(4, occurances[0]);
            Assert.AreEqual(6, occurances[1]);
            Assert.AreEqual(15, occurances[2]);
        }

        [TestCase]
        public void HashedSearch_Should_Find_All_Occurances()
        {
            // arrange

            // act
            var occurances = Text.HashedSearch(Pattern);

            // assert
            Assert.IsNotNull(occurances);
            Assert.AreEqual(3, occurances.Length);
            Assert.AreEqual(4, occurances[0]);
            Assert.AreEqual(6, occurances[1]);
            Assert.AreEqual(15, occurances[2]);
        }
    }
}
