using Microsoft.EntityFrameworkCore;

namespace Rebtel.DeveloperTest.DAL
{
    internal static class LibraryContextSeedData
    {

        private static Book CreateBook(int id, string name, string author, int numberOfCopies, int pages)
        {
            return new Book
            {
                BookId = id,
                Name = name,
                Author = author,
                NumberOfCopies = numberOfCopies,
                Pages = pages
            };
        }

        private static Borrower CreateBorrower(int borrowerId, string borrowerName, string email)
        {

            return new Borrower
            {
                BorrowerId = borrowerId,
                Name = borrowerName,
                Email = email,
            };
        }

        private static BorrowerHistory CreateBorrowerHistory(int id, Book book, int bookId, Borrower borrower, int borrowId, DateTime startDate, DateTime? endDate = null)
        {
            return new BorrowerHistory { BorrowerHistoryId = id, BookId = bookId, BorrowerId = borrowId, StartDate = startDate, EndDate = endDate };
        }

        internal static void SeedLibraryDataContext(ModelBuilder modelBuilder)
        {
            Book book1 = CreateBook(1, "B1", "A1", 10, 100);
            Book book2 = CreateBook(2, "B2", "A2", 5, 200);
            Book book3 = CreateBook(3, "B3", "A3", 10, 250);
            Book book4 = CreateBook(4, "B4", "A4", 5, 300);

            Borrower borrower1 = CreateBorrower(1, "Br1", "br1@b.com");
            Borrower borrower2 = CreateBorrower(2, "Br2", "br2@b.com");
            Borrower borrower3 = CreateBorrower(3, "Br3", "br3@b.com");
            Borrower borrower4 = CreateBorrower(4, "Br4", "br4@b.com");

            BorrowerHistory borrowerHistory1 = CreateBorrowerHistory(1, book1, book1.BookId, borrower1, borrower1.BorrowerId, new DateTime(2024, 05, 09), new DateTime(2024, 06, 09));
            BorrowerHistory borrowerHistory2 = CreateBorrowerHistory(2, book2, book2.BookId, borrower2, borrower2.BorrowerId, new DateTime(2024, 07, 09), new DateTime(2024, 08, 09));
            BorrowerHistory borrowerHistory3 = CreateBorrowerHistory(3, book3, book3.BookId, borrower3, borrower3.BorrowerId, new DateTime(2024, 09, 09), new DateTime(2024, 10, 09));
            BorrowerHistory borrowerHistory4 = CreateBorrowerHistory(4, book4, book4.BookId, borrower4, borrower4.BorrowerId, new DateTime(2024, 11, 09), new DateTime(2024, 12, 09));

            BorrowerHistory borrowerHistory5 = CreateBorrowerHistory(5, book2, book2.BookId, borrower1, borrower1.BorrowerId, new DateTime(2024, 01, 09), new DateTime(2024, 02, 09));
            BorrowerHistory borrowerHistory6 = CreateBorrowerHistory(6, book4, book4.BookId, borrower1, borrower1.BorrowerId, new DateTime(2024, 03, 09), new DateTime(2024, 04, 09));
            modelBuilder.Entity<Book>().HasData(
                book1, book2, book3, book4
            );

            modelBuilder.Entity<Borrower>().HasData(
                borrower1, borrower2, borrower3, borrower4
            );

            modelBuilder.Entity<BorrowerHistory>().HasData(
                borrowerHistory1, borrowerHistory2, borrowerHistory3, borrowerHistory4, borrowerHistory5, borrowerHistory6
           );
        }
    }
}
