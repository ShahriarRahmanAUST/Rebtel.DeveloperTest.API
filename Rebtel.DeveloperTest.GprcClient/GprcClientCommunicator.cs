using Google.Protobuf.WellKnownTypes;
using GPRCClientDLL;
using Grpc.Net.Client;
using static GPRCClientDLL.BookDetails;
using static GPRCClientDLL.BorrowerDetails;


namespace Rebtel.DeveloperTest.GprcClient
{
    public class GprcClientCommunicator : IGprcClientCommunicator
    {
        private readonly BorrowerDetailsClient _borrowerDetailsClient;
        private readonly BookDetailsClient _bookDetailsClient;

        public GprcClientCommunicator()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50248");
            _borrowerDetailsClient = new BorrowerDetails.BorrowerDetailsClient(channel);
            _bookDetailsClient = new BookDetails.BookDetailsClient(channel);
        }
        
        public async Task<BorrowerReadingRate> CalculateBorrowerReadingRate(int borrowerId)
        {
            return await _borrowerDetailsClient.CalculateBorrowerReadingRateAsync(new BorrowerRequest
                { BorrowerId = borrowerId });
        }

        public Task<BookDetailsInfoList> GetBorrowingPattern(int borrowerId, int bookIdToExclude)
        {
            var getBorrowingPattern = _bookDetailsClient.GetBorrowingPattern(new BorrowingPatternRequest
                { BorrowerId = borrowerId, BookToExcludeId = bookIdToExclude });

            return Task.FromResult(getBorrowingPattern);
        }

        public Task<BookDetailsInfoList> GetMaxBook()
        {
            var getMaximumBorrowerBook = _bookDetailsClient.GetMaxBorrowedBook(new Empty());

            return Task.FromResult(getMaximumBorrowerBook);
        }

        public async Task<BorrowerDetailsInfoList> GetMaxBorrower(DateTime startDate, DateTime endDate)
        {
            var startDateTimeStamp = Timestamp.FromDateTimeOffset(startDate);
            var endDateTimeStamp = Timestamp.FromDateTimeOffset(endDate);

            var borrowerDetailsInfoList = await _borrowerDetailsClient.MostBorrowerAsync(new BookBorrowTimeframe
                { StartDate = startDateTimeStamp, EndDate = endDateTimeStamp });
            
            return borrowerDetailsInfoList;
        }
    }
}