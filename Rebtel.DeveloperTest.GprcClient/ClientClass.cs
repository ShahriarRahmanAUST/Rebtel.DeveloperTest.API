using System.Resources;
using Google.Protobuf.WellKnownTypes;
using GPRCClientDLL;
using Grpc.Net.Client;
using Google.Protobuf.WellKnownTypes;


namespace Rebtel.DeveloperTest.GprcClient
{
    public class ClientClass : IClientClass
    {
        public async Task<BorrowerReadingRate> CalculateBorrowerReadingRate(int borrowerId)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50248");
            var client = new BorrowerDetails.BorrowerDetailsClient(channel);
            return await client.CalculateBorrowerReadingRateAsync(new BorrowerRequest{BorrowerId = borrowerId});
        }

        public Task<BookDetailsInfoList> GetBorrowingPattern(int borrowerId, int bookIdToExclude)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50248");

            var client = new BookDetails.BookDetailsClient(channel);
            var getBorrowingPattern = client.GetBorrowingPattern(new BorrowingPatternRequest{BorrowerId = borrowerId, BookToExcludeId = bookIdToExclude});

            return Task.FromResult(getBorrowingPattern);
        }

        public Task<BookDetailsInfoList> GetMaxBook()
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50248");

            var client = new BookDetails.BookDetailsClient(channel);
            var getMaximumBorrowerBook = client.GetMaxBorrowedBook(new Empty());

            return Task.FromResult(getMaximumBorrowerBook);
        }

        public async Task<BorrowerDetailsInfoList> GetMaxBorrower(DateTime startDate, DateTime endDate)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:50248");
            var client = new BorrowerDetails.BorrowerDetailsClient(channel);


            var startDateTimeStamp = Timestamp.FromDateTimeOffset(startDate);
            var endDateTimeStamp = Timestamp.FromDateTimeOffset(endDate);

            var borrowerDetailsInfoList = await client.MostBorrowerAsync(new BookBorrowTimeframe
                { StartDate = startDateTimeStamp, EndDate = endDateTimeStamp });


            return borrowerDetailsInfoList;
        }
    }
}