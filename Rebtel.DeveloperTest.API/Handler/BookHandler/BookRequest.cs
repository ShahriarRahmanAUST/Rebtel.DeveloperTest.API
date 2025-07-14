using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BookHandler
{
    public class BookRequest : IRequest<AvaiableBook>, IRequest<int>
    {
        public int BookId { get; set; }
    }
}
