using System.ComponentModel.DataAnnotations.Schema;

public class BorrowerHistory
{
    public int BorrowerHistoryId { get; set; }
    [ForeignKey("BookId")]
    public Book Book { get; set; }
    public int BookId { get; set; }
    [ForeignKey("BorrowerId")]
    public Borrower Borrower { get; set; }
    public int BorrowerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}