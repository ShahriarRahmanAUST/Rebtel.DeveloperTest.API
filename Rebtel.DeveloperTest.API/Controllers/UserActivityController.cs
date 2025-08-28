using GPRCClientDLL;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rebtel.DeveloperTest.API.Handler.BorrowerHandler;
using Rebtel.DeveloperTest.API.Logger;
using System.Diagnostics;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Rebtel.DeveloperTest.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class UserActivityController(IMediator mediator, ILogMessage logger) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetMostFrequentBorrower(DateTime startDate, DateTime endDate,
            CancellationToken cancellationToken)
        {
            var watch = Stopwatch.StartNew();

            if (endDate < startDate) return BadRequest("End Date cannot be ahead of Start Date");

            try
            {
                var request = new MostFrequentBorrowerRequest() { StartDate = startDate, EndDate = endDate };
                var borrowerDetailsInfoList = await mediator.Send<BorrowerDetailsInfoList>(request, cancellationToken);

                return Ok(borrowerDetailsInfoList);
            }
            catch (Exception ex) when (ex is TaskCanceledException or OperationCanceledException)
            {
                logger.LogError(ex.Message);
                return BadRequest("Call Cancled");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                logger.LogInof(
                    $"GetBookListByBorrower took {watch.ElapsedMilliseconds} ms, request with start Date {startDate} and  end Date {endDate}");
            }
        }

        [HttpGet]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK)]
        [ProducesResponseType(statusCode: StatusCodes.Status204NoContent)]
        [ProducesResponseType(statusCode: StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<string>> GetReadingRateOfBorrower(int borrowerId,
            CancellationToken cancellationToken)
        {
            var watch = Stopwatch.StartNew();

            try
            {
                var request = new BorrowerReadingRateRequest() { BorrowerId = borrowerId };
                var borrowerReadingRate = await mediator.Send<BorrowerReadingRate>(request, cancellationToken);

                return Ok(borrowerReadingRate);
            }
            catch (Exception ex) when (ex is TaskCanceledException or OperationCanceledException)
            {
                logger.LogError(ex.Message);
                return BadRequest("Call Cancled");
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
            finally
            {
                logger.LogInof(
                    $"GetReadingRateOfBorrower took {watch.ElapsedMilliseconds} ms, request with borrowerId {borrowerId}");
            }
        }
    }
}