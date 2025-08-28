using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rebtel.DeveloperTest.SL.DTO;
using Rebtel.DeveloperTest.SL.Interfaces;
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

        public async Task<AvailableBookDto> GetAvailableBook(int bookId)
        {
            var book = await LibraryContext.Books.Where(x => x.BookId == bookId).FirstOrDefaultAsync();
            if (book == null) return new AvailableBookDto { TotalBook = 0, TotalBorrowerd = 0 };
            var totalBorrowed = await LibraryContext.BorrowerHistories
                .Where(x => x.BookId == bookId && x.EndDate == null).ToListAsync();
            var totalBorrowedCount = 0;
            var xx = JsonSerializer.Serialize(LibraryContext.Books.ToList());
            if (totalBorrowed.Any())
            {
                totalBorrowedCount = totalBorrowed.Count();
            }

            return new AvailableBookDto
                { BookId = bookId, TotalBook = book.NumberOfCopies, TotalBorrowerd = totalBorrowedCount };
        }

        public async Task<List<BookDto>> GetMaxBook()
        {
            var maxBook = await LibraryContext.BorrowerHistories.GroupBy(b => b.BookId)
                .OrderByDescending(x => x.Count()).Select(g => new { bookId = g.Key, count = g.Count() }).ToListAsync();

            var maxValue = maxBook[0].count;

            var bookList = maxBook.Where(x => x.count == maxValue).Select(x => x.bookId).ToList();
            var books = await LibraryContext.Books.Where(r => bookList.Contains(r.BookId)).ToListAsync();
            List<BookDto> returnedbookList = new List<BookDto>();
            foreach (var book in books)
            {
                returnedbookList.Add(new BookDto
                {
                    Author = book.Author, BookId = book.BookId, Name = book.Name, NumberOfCopies = book.NumberOfCopies,
                    Pages = book.Pages
                });
            }

            return returnedbookList;
        }


        public async Task<List<BookDto>> BookListByBorrower(int borrowerId, int bookIdtoExclude)
        {
            var histories = LibraryContext.BorrowerHistories.Where(x => x.BorrowerId == borrowerId)
                .Where(x => x.BookId != bookIdtoExclude).ToList();
            var bookSLs = new List<BookDto>();
            foreach (var borrowerHistory in histories)
            {
                var book = await LibraryContext.Books.Where(x => x.BookId == borrowerHistory.BookId)
                    .FirstOrDefaultAsync();
                if (book != null)
                    bookSLs.Add(new BookDto
                    {
                        Author = book.Author, BookId = book.BookId, Name = book.Name,
                        NumberOfCopies = book.NumberOfCopies,
                        Pages = book.Pages
                    });
            }

            return bookSLs;
        }
    }
}