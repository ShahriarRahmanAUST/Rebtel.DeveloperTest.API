using Microsoft.EntityFrameworkCore;

[Index(nameof(Email))]
public record Borrower
{
    public int BorrowerId { get; set; }
    public required string Name { get; set; }
    public required string Email { get; set; }
}
