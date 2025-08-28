using Rebtel.DeveloperTest.SL.DTO;

namespace Rebtel.DeveloperTest.SL.Interfaces
{
    public interface IBookLogic
    {
        public Task<List<BookDto>> GetMaxBook(CancellationToken contextCancellationToken);
        public Task<List<BookDto>> BookListByBorrower(int borrowerId, int bookIdtoExclude,
            CancellationToken contextCancellationToken);
    }
}