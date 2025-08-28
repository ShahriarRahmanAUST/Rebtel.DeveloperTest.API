using GprcServer;
using Grpc.Core;
using Rebtel.DeveloperTest.SL.Interfaces;


namespace Rebtel.DeveloperTest.GprcServer.Services;

public class BorrowerService : BorrowerDetails.BorrowerDetailsBase
{
    private readonly ILogger<BorrowerService> _logger;
    private readonly IBookLogic bookLogic;
    private readonly IBorrowerLogic _borrowerLogic;

    public BorrowerService(ILogger<BorrowerService> logger, IBookLogic bookLogic, IBorrowerLogic borrowerLogic)
    {
        _logger = logger;
        this.bookLogic = bookLogic;
        _borrowerLogic = borrowerLogic;
    }

    public override async Task<BorrowerDetailsInfoList> MostBorrower(BookBorrowTimeframe request,
        ServerCallContext context)
    {
        var borrowerList =
            await _borrowerLogic.MaxBookBorrower(request.StartDate.ToDateTime(), request.EndDate.ToDateTime(), context.CancellationToken);

        var borrowerDetailsInfoList = new BorrowerDetailsInfoList();
        foreach (var borrower in borrowerList)
        {
            borrowerDetailsInfoList.BorrowerDetailsInfoList_.Add(new BorrowerDetailsInfo
                { BorrowerId = borrower.BorrowerId, Name = borrower.Name, Email = borrower.Email });
        }

        return borrowerDetailsInfoList;
    }

    public override async Task<BorrowerReadingRate> CalculateBorrowerReadingRate(BorrowerRequest request,
        ServerCallContext context)
    {
        var readingRate = await _borrowerLogic.CalculateReadingRate(request.BorrowerId, context.CancellationToken);
        return new BorrowerReadingRate { BorrowerId = request.BorrowerId, BorrowerReadingRatePagePerDay = readingRate };
    }
}