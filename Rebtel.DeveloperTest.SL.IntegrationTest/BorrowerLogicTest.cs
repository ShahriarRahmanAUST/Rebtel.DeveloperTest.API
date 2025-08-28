
using Newtonsoft.Json;

namespace Rebtel.DeveloperTest.SL.UnitTest
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
            //var result = _sut.BookListByBorrower(1, 1);
            //Assert.AreEqual(result.Result.Count, 2);
        }
    }
}
