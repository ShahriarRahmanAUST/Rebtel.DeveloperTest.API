namespace Rebtel.DeveloperTest.BLL
{
    public interface IBookLogic
    {

        public  Task<BookSL> GetMaxBook();

        public Task<AvaiableBook> GetAvailableBook(int bookId);
    }
}