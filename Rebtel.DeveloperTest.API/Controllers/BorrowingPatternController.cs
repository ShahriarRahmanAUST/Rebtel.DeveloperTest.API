using GPRCClientDLL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebtel.DeveloperTest.API.Handler.BorrowingPatterHandler;
using Rebtel.DeveloperTest.API.Logger;
using System.Diagnostics;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebtel.DeveloperTest.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BorrowingPatternController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogMessage _logger;

        public BorrowingPatternController(IMediator mediator, ILogMessage logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetBorrowingPattern(int borrowerId, int bookIdToExclude,
            CancellationToken cancellation)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                var request = new BorrowingPatternHandlerRequest()
                    { BorrowerId = borrowerId, BookIdToExclude = bookIdToExclude };
                var bookDetailsInfoList = await _mediator.Send<BookDetailsInfoList>(request, cancellation);

                if (bookDetailsInfoList.BookDetailsInfoList_.Count == 0)
                {
                    return NoContent();
                }

                return Ok(bookDetailsInfoList);
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
                _logger.LogInof(
                    $"MostBorrowedBooks took {watch.ElapsedMilliseconds} ms, request with borrowerId {borrowerId} and bookIdToExclude {bookIdToExclude}");
            }
        }
    }
}