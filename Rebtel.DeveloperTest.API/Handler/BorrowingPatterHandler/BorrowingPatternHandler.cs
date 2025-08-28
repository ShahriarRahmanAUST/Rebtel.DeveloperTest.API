using GPRCClientDLL;
using MediatR;
using Rebtel.DeveloperTest.GprcClient;

namespace Rebtel.DeveloperTest.API.Handler.BorrowingPatterHandler;

public class BorrowingPatternHandler(IGprcClientCommunicator clientClass) : IRequestHandler<BorrowingPatternHandlerRequest, BookDetailsInfoList>
{
    public async Task<BookDetailsInfoList> Handle(BorrowingPatternHandlerRequest request, CancellationToken cancellationToken)
    {
       return await clientClass.GetBorrowingPattern(request.BorrowerId, request.BookIdToExclude);
    }
}