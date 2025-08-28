namespace Rebtel.DeveloperTest.WarmUpTasks.UnitTest
{
    [TestClass]
    public sealed class LibraryUtilityTest
    {
        [TestMethod]
        public void CheckIsBookIdPowerOfTwo()
        {
            Assert.AreEqual(true, LibraryUtility.IsBookIdPowerOfTwo(128));
            Assert.AreEqual(false, LibraryUtility.IsBookIdPowerOfTwo(99));
        }

        [TestMethod]
        public void CheckReverseBookTitle()
        {
            string title = "B1";
            var bookTitleReversed = LibraryUtility.ReverseBookTitle(title);
            Assert.AreEqual(title[0], bookTitleReversed[1]);
            Assert.AreEqual(title[1], bookTitleReversed[0]);
        }

        [TestMethod]
        public void CheckGenerateBookTitleReplicas()
        {
            string title = "B1";
            var bookTitleReplicas = LibraryUtility.GenerateBookTitleReplicas(title, 3);
            Assert.AreEqual(bookTitleReplicas, title + title + title);
        }

        [TestMethod]
        public void CheckAllOddNumbersBetweenZeroTwoHundred()
        {
            var allOddNumbers = LibraryUtility.AllOddNumberBetweenZeroToHundred();
            Assert.AreEqual(50, allOddNumbers.Count);
            Assert.AreEqual(1, allOddNumbers.First());
            Assert.AreEqual(99, allOddNumbers.Last());
        }
    }
}