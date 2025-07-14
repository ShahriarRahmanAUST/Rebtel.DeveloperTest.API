namespace Rebtel.DeveloperTest.BLL
{
    public interface IBookLogic
    {

        public  Task<BookSL> GetMaxBook();

        public AvaiableBook? GetAvailableBook(int bookId);
    }
}