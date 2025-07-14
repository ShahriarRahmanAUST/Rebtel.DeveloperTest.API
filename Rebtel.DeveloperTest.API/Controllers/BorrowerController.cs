using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebtel.DeveloperTest.API.Handler.BookHandler;
using Rebtel.DeveloperTest.API.Handler.BorrowerHandler;
using Rebtel.DeveloperTest.API.Logger;
using Rebtel.DeveloperTest.BLL;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebtel.DeveloperTest.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BorrowerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogMessage _logger;

        public BorrowerController(IMediator mediator, ILogMessage logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetBookListByBorrower(int borrowerId, int bookIdToExclude, CancellationToken cancellationToken)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                var request = new BorrowerRequest() { BorrowerId = borrowerId, BookIdToExclude = bookIdToExclude };
                var books = await _mediator.Send<List<BookSL>>(request, cancellationToken);
                if (books.Count == 0)
                {
                    return NoContent();
                }
                return Ok(books);
            }
            catch (Exception ex) when (ex is TaskCanceledException or OperationCanceledException)
            {
                _logger.LogError(ex.Message);
                return BadRequest("Call Cancled");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                _logger.LogInof($"GetBookListByBorrower took {watch.ElapsedMilliseconds} ms, request with borrowerId {borrowerId} and  bookId to exclude {bookIdToExclude}");
            }
        }

    }

}
