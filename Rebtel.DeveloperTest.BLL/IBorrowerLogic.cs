using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.SL
{
    public  interface IBorrowerLogic
    {
        public Task<List<BookSL>> BookListByBorrower(int borrowerId, int bookIdtoExclude);

        public BorrowerSL MaxBookBorrower(DateTime startDate, DateTime endDate);
    }
}