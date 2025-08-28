using Rebtel.DeveloperTest.SL.DTO;

namespace Rebtel.DeveloperTest.SL.Interfaces
{
    public  interface IBorrowerLogic
    {
        public Task<List<BorrowerDto>> MaxBookBorrower(DateTime startDate, DateTime endDate,
            CancellationToken contextCancellationToken);
        public Task<int> CalculateReadingRate(int borrowerId, CancellationToken contextCancellationToken);
    }
}