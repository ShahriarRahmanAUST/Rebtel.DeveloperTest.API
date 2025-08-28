using GPRCClientDLL;
using MediatR;
using Rebtel.DeveloperTest.GprcClient;


namespace Rebtel.DeveloperTest.API.Handler.BorrowerHandler
{
    public class MostFrequentBorrowerHandler(IGprcClientCommunicator clientClass)
        : IRequestHandler<MostFrequentBorrowerRequest, BorrowerDetailsInfoList>
    {
        public async Task<BorrowerDetailsInfoList> Handle(MostFrequentBorrowerRequest request,
            CancellationToken cancellationToken)
        {
            return await clientClass.GetMaxBorrower(request.StartDate, request.EndDate, cancellationToken);
        }
    }

    public class BorrowerReadingRateHandler(IGprcClientCommunicator clientClass)
        : IRequestHandler<BorrowerReadingRateRequest, BorrowerReadingRate>
    {
        public async Task<BorrowerReadingRate> Handle(BorrowerReadingRateRequest request,
            CancellationToken cancellationToken)
        {
            return await clientClass.CalculateBorrowerReadingRate(request.BorrowerId, cancellationToken);
        }
    }
}