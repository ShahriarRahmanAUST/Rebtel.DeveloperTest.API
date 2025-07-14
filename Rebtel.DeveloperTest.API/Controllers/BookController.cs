using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebtel.DeveloperTest.API.Handler;
using Rebtel.DeveloperTest.API.Handler.BookHandler;
using Rebtel.DeveloperTest.API.Logger;
using Rebtel.DeveloperTest.BLL;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebtel.DeveloperTest.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogMessage _logger;

        public BookController(IMediator mediator, ILogMessage logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetAvailableBooks(int bookId, CancellationToken cancellationToken)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                var request = new BookRequest() { BookId = bookId };
                var avaiableBook = await _mediator.Send<AvaiableBook>(request, cancellationToken);
                if (avaiableBook.TotalBook == 0)
                {
                    return NoContent();
                }
                return Ok(avaiableBook);
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
                _logger.LogInof($"GetAvailableBooks took {watch.ElapsedMilliseconds} ms, request with bookId {bookId}");
            }
        }
    }
}
