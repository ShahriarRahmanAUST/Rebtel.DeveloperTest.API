using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BookHandler
{
    public class BookHandler : IRequestHandler<BookRequest, BookSL>
    {
        IBookLogic _bookLogic;
        public BookHandler(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }
        public async Task<BookSL> Handle(BookRequest request, CancellationToken cancellationToken)
        {
            return await _bookLogic.GetMaxBook();            
        }
    }
}
