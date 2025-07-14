using Microsoft.EntityFrameworkCore;

public interface ILibraryContext
{
    DbSet<Book> Books { get; set; }
    DbSet<Borrower> Borrowers { get; set; }
    DbSet<BorrowerHistory> BorrowerHistories { get; set; }
}