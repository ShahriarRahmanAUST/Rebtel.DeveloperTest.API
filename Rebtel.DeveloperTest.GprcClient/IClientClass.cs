using GPRCClientDLL;

namespace Rebtel.DeveloperTest.GprcClient;

public interface IClientClass
{
    Task<BookDetailsInfoList> GetMaxBook();
    Task<BorrowerDetailsInfoList> GetMaxBorrower(DateTime startDate, DateTime endDate);
    Task<BorrowerReadingRate> CalculateBorrowerReadingRate(int borrowerId);
    Task<BookDetailsInfoList> GetBorrowingPattern(int borrowerId, int bookIdToExclude);
}