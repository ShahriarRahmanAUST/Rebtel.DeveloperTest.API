namespace Rebtel.DeveloperTest.SL.DTO;

public record AvailableBookDto
{
    public int BookId { get; set; }
    public int TotalBook { get; set; }
    public int TotalBorrowerd { get; set; }
}