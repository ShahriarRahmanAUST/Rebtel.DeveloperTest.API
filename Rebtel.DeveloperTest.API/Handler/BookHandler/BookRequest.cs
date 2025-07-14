using MediatR;
using Rebtel.DeveloperTest.BLL;

namespace Rebtel.DeveloperTest.API.Handler.BookHandler
{
    public class BookRequest : IRequest<Microsoft.AspNetCore.Mvc.ActionResult<string>>, IRequest<BookSL>
    {
        public int BookId { get; set; }
    }
}
