using MediatR;
using Rebtel.DeveloperTest.API.Handler.BookHandler;
using Rebtel.DeveloperTest.BLL;
using Rebtel.DeveloperTest.SL;

namespace Rebtel.DeveloperTest.API.Handler.BorrowerHandler
{
    public class BookListByBorrowerHandler : IRequestHandler<BorrowerRequest, List<BookSL>>
    {
        IBorrowerLogic _borrowerLogic;
        public BookListByBorrowerHandler(IBorrowerLogic borrowerLogic)
        {
            _borrowerLogic = borrowerLogic;
        }
        public async Task<List<BookSL>> Handle(BorrowerRequest request, CancellationToken cancellationToken)
        {
            return await _borrowerLogic.BookListByBorrower(request.BorrowerId, request.BookIdToExclude);
        }
    }
}
