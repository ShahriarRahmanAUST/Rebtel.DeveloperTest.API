using Rebtel.DeveloperTest.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rebtel.DeveloperTest.SL
{

    public class BorrowerSL
    {
        public int BorrowerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    public class BorrowerLogic: IBorrowerLogic
    {
        public readonly ILibraryContext LibraryContext;
        public BorrowerLogic(ILibraryContext libraryContext)
        {
            LibraryContext = libraryContext;
        }

        public BorrowerSL MaxBookBorrower(DateTime startDate, DateTime endDate)
        {
            var borrower = LibraryContext.BorrowerHistories.Where(x=> x.StartDate >= endDate && x.EndDate<=endDate).GroupBy(b => b.BorrowerId).OrderByDescending(x => x.Count()).Select(z => z.First().Borrower).Take(1).FirstOrDefault();
            var mapper = MapperConfig.Mapper;
            return mapper.Map<BorrowerSL>(borrower);
        }

        public List<BookSL> BookListByBorrower(int borrowerId, int bookIdtoExclude)
        {
            var histories = LibraryContext.BorrowerHistories.Where(x => x.BorrowerId == borrowerId).Where(x=>x.BookId != bookIdtoExclude).GroupBy(b => b.BorrowerId).ToList();
            
            var borrowerHistories = histories[0].ToList();
            var mapper = MapperConfig.Mapper;

            List<BookSL> bookSLs = new List<BookSL>();
            foreach (var borrowerHistory in borrowerHistories)
            { 
                bookSLs.Add(mapper.Map<BookSL>(borrowerHistory.Book));
            }
            return bookSLs;

        }
    }
}
