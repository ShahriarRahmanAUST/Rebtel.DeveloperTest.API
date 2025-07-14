using Microsoft.EntityFrameworkCore;
using Moq;
using Newtonsoft.Json;
using System.Collections.Generic;
using Moq.EntityFrameworkCore;

namespace Rebtel.DeveloperTest.SL.UnitTest
{
    [TestClass]
    public sealed class BorrowerLogicTest
    {
        BorrowerLogic _sut;        

        [TestInitialize]
        public void TestSetup()
        {
            List<BorrowerHistory> borrowerHistories = null;
            using (StreamReader r = new StreamReader("BorrowerHistory.json"))
            {
                string json = r.ReadToEnd();
                borrowerHistories = JsonConvert.DeserializeObject<List<BorrowerHistory>>(json);
            }
            var libraryContext = new Mock<ILibraryContext>();
            libraryContext.Setup(x => x.BorrowerHistories).ReturnsDbSet(borrowerHistories);
            _sut = new BorrowerLogic(libraryContext.Object);
            
        }


        [TestMethod]
        public void BookListByBorrowerShouldReturnListOfBooksAndExcluedOneBook()
        {
            var result = _sut.BookListByBorrower(1,1);
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].BookId, 2);
            Assert.AreEqual(result[1].BookId, 4);
        }
    }
}
