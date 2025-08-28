
namespace Rebtel.DeveloperTest.SL.IntegrationTest
{
    [TestClass]
    public sealed class BorrowerLogicTest
    {
        BorrowerLogic _sut;
        [TestInitialize]
        public void TestSetup()
        {
            var libraryContext = new LibraryContext();
            _sut = new BorrowerLogic(libraryContext);
        }

        [TestMethod]
        public void BookListByBorrowerShouldReturnListOfBooksAndExcluedOneBook()
        {
            var result = _sut.CalculateReadingRate(1, CancellationToken.None);
            Assert.AreEqual(result.Result, 6);
        }
    }
}
