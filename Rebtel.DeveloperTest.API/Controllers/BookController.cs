using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebtel.DeveloperTest.API.Handler;
using Rebtel.DeveloperTest.API.Handler.BookHandler;
using Rebtel.DeveloperTest.BLL;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebtel.DeveloperTest.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetMaxBook(int bookId, CancellationToken cancellationToken)
        {
            var request = new BookRequest() { BookId  = bookId };
            var maxBook = await _mediator.Send<BookSL>(request, cancellationToken);
            return Ok(maxBook);
        }
    }
}
