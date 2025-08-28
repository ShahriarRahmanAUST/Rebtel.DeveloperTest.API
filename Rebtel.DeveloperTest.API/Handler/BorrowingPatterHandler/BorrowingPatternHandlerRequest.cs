using GPRCClientDLL;
using MediatR;

namespace Rebtel.DeveloperTest.API.Handler.BorrowingPatterHandler;

public class BorrowingPatternHandlerRequest : IRequest<BookDetailsInfoList>
{
    public int BorrowerId { get; set; }
    public int BookIdToExclude { get; set; }
}