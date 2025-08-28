using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Rebtel.DeveloperTest.BLL;
using Rebtel.DeveloperTest.SL.DTO;
using Rebtel.DeveloperTest.SL.Interfaces;
using System.Net;

namespace Rebtel.DeveloperTest.SL
{
    public class BorrowerLogic : IBorrowerLogic
    {
        public readonly ILibraryContext LibraryContext;

        public BorrowerLogic(ILibraryContext libraryContext)
        {
            LibraryContext = libraryContext;
        }

        public async Task<List<BorrowerDto>> MaxBookBorrower(DateTime startDate, DateTime endDate)
        {
            var maxBorrower = await LibraryContext.BorrowerHistories
                .Where(x => x.EndDate < endDate && x.StartDate > startDate).GroupBy(b => b.BorrowerId)
                .OrderByDescending(x => x.Count()).Select(g => new { borrowerId = g.Key, count = g.Count() })
                .ToListAsync();
            var maxValue = maxBorrower[0].count;
            var borrowerList = maxBorrower.Where(x => x.count == maxValue).Select(x => x.borrowerId).ToList();
            var borrowers = await LibraryContext.Borrowers.Where(r => borrowerList.Contains(r.BorrowerId))
                .ToListAsync();

            return borrowers.Select(borrower => new BorrowerDto()
                { BorrowerId = borrower.BorrowerId, Email = borrower.Email, Name = borrower.Name }).ToList();
        }

        public async Task<int> CalculateReadingRate(int borrowerId)
        {
            var borrowHistory =
                await LibraryContext.BorrowerHistories.Where(x => x.BorrowerId == borrowerId).ToListAsync();
            return CalculateDays(borrowHistory);
        }

        private int CalculateDays(List<BorrowerHistory> borrowHistories)
        {
            int totalDays = 0;
            int totalPage = 0;
            foreach (var borrowHistory in borrowHistories)
            {
                DateTime endDate = DateTime.Now;
                if (borrowHistory.EndDate != null)
                {
                    endDate = borrowHistory.EndDate.Value;
                }

                totalDays += (endDate - borrowHistory.StartDate).Days;

                var book = LibraryContext.Books.FirstOrDefault(x => x.BookId == borrowHistory.BookId);
                if (book == null) return 0;
                totalPage = totalPage + book.Pages;
            }

            return (totalDays > 0) ? totalPage / totalDays : 0;
        }
    }
}