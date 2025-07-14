using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.SL
{
    public class BorrowerLogic: IBorrowerLogic
    {
        public readonly ILibraryContext LibraryContext;
        public readonly Mapper mapper;

        public BorrowerLogic(ILibraryContext libraryContext)
        {
            LibraryContext = libraryContext;
            mapper = MapperConfig.Mapper;
        }

        public BorrowerSL MaxBookBorrower(DateTime startDate, DateTime endDate)
        {
            var borrower = LibraryContext.BorrowerHistories.Where(x=> x.StartDate >= endDate && x.EndDate<=endDate).GroupBy(b => b.BorrowerId).OrderByDescending(x => x.Count()).Select(z => z.First().Borrower).Take(1).FirstOrDefault();            
            return mapper.Map<BorrowerSL>(borrower);
        }

        public async Task<List<BookSL>> BookListByBorrower(int borrowerId, int bookIdtoExclude)
        {
            var histories = LibraryContext.BorrowerHistories.Where(x => x.BorrowerId == borrowerId).Where(x=>x.BookId != bookIdtoExclude).ToList();                      
            var bookSLs = new List<BookSL>();
            foreach (var borrowerHistory in histories)
            { 
                var book = await LibraryContext.Books.Where(x => x.BookId == borrowerHistory.BookId).FirstOrDefaultAsync();
                bookSLs.Add(mapper.Map<BookSL>(book));
            }

            return bookSLs;
        }
    }
}
