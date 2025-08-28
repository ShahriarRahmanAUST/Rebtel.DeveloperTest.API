using GPRCClientDLL;

namespace Rebtel.DeveloperTest.GprcClient;

public interface IGprcClientCommunicator
{
    Task<BookDetailsInfoList> GetMaxBook(CancellationToken cancellationToken);
    Task<BorrowerDetailsInfoList> GetMaxBorrower(DateTime startDate, DateTime endDate,
        CancellationToken cancellationToken);
    Task<BorrowerReadingRate> CalculateBorrowerReadingRate(int borrowerId, CancellationToken cancellationToken);
    Task<BookDetailsInfoList> GetBorrowingPattern(int borrowerId, int bookIdToExclude,
        CancellationToken cancellationToken);
}