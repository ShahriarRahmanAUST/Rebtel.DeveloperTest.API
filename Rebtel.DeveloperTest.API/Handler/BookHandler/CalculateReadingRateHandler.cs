using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BookHandler
{
    public class CalculateReadingRateHandler : IRequestHandler<BookRequest, int>
    {

        IBookLogic _bookLogic;
        public CalculateReadingRateHandler(IBookLogic bookLogic)
        {
            _bookLogic = bookLogic;
        }
        public async Task<int> Handle(BookRequest request, CancellationToken cancellationToken)
        {
            return await _bookLogic.CalculateReadingRate(request.BookId);
        }
    }
}
