using GPRCClientDLL;
using MediatR;


namespace Rebtel.DeveloperTest.API.Handler.BorrowerHandler
{
   
    public class MostFrequentBorrowerRequest : IRequest<BorrowerDetailsInfoList>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class BorrowerReadingRateRequest : IRequest<BorrowerReadingRate>
    {
        public int BorrowerId { get; set; }
    }
}