using GPRCClientDLL;
using MediatR;


namespace Rebtel.DeveloperTest.API.Handler.InventoryInsightHandler
{
    public class BookRequest : IRequest<int>, IRequest<BookDetailsInfoList>
    {
        public int BookId { get; set; }
    }
}
