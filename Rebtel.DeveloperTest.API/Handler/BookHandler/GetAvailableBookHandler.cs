using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BookHandler
{
    public class GetAvailableBookHandler : IRequestHandler<BookRequest, AvaiableBook>
    {
        IBookLogic _bookLogic;
        public GetAvailableBookHandler(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }
        public async Task<AvaiableBook> Handle(BookRequest request, CancellationToken cancellationToken)
        {
            return await _bookLogic.GetAvailableBook(request.BookId);            
        }
    }
}
