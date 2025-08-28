using System.ComponentModel.DataAnnotations.Schema;

public record BorrowerHistory
{
    public int BorrowerHistoryId { get; set; }
    public  Book Book { get; set; }
    [ForeignKey("BookId")]
    public int BookId { get; set; }
    public  Borrower Borrower { get; set; }
    [ForeignKey("BorrowerId")]
    public int BorrowerId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}