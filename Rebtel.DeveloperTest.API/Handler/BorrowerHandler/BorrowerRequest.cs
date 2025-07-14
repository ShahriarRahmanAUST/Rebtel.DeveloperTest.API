using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BorrowerHandler
{
    public class BorrowerRequest : IRequest<List<BookSL>>
    {
        public int BookIdToExclude { get; set; }
        public int BorrowerId { get; set; }
    }
}
