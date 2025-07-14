using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace Rebtel.DeveloperTest.BLL
{
    public class BooksLogic : IBookLogic
    {
        public readonly ILibraryContext LibraryContext;
        public BooksLogic(ILibraryContext libraryContext)
        {

            LibraryContext = libraryContext;


        }

        public AvaiableBook? GetAvailableBook(int bookId)
        {
            var book = LibraryContext.Books.Where(x => x.BookId == bookId).FirstOrDefault();
            if (book == null) return null;
            var totalBorowod = LibraryContext.BorrowerHistories.Where(x => x.BookId == bookId && x.EndDate == null).ToList();
            var totalBorrowedCount = 0;
            if (totalBorowod.Any())
            {
                totalBorrowedCount = totalBorowod.Count();
            }

            return new AvaiableBook { BookId = bookId, TotalBook = book.NumberOfCopies, TotalBorrowerd = totalBorrowedCount };
        }

        public async Task<BookSL> GetMaxBook()
        {
            var maxBook = await LibraryContext.BorrowerHistories.GroupBy(b => b.BookId).OrderByDescending(x => x.Count()).Select(n => n.First().Book).Take(1).FirstOrDefaultAsync();
            var json = JsonSerializer.Serialize(LibraryContext.BorrowerHistories.ToList());
            var mapper = MapperConfig.Mapper;
            return mapper.Map<BookSL>(maxBook);
        }

        public int CalculateReadingRate(int bookId)
        {
            var borrowHistory = LibraryContext.BorrowerHistories.Where(x => x.BookId == bookId).ToList();
            int totalDays = CalculateDays(borrowHistory);
            return (int)borrowHistory.First().Book.Pages / totalDays;
        }

        private int CalculateDays(List<BorrowerHistory> borrowHistories)
        {
            int totalDays = 0;

            foreach (var borrowHistory in borrowHistories)
            {
                DateTime endDate = DateTime.Now;
                if (borrowHistory.EndDate != null)
                {
                    endDate = borrowHistory.EndDate.Value;
                }

                totalDays += (endDate - borrowHistory.StartDate).Days;
            }

            return totalDays;

        }
    }
}
