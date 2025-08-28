
using GPRCClientDLL;
using MediatR;
using Rebtel.DeveloperTest.GprcClient;

namespace Rebtel.DeveloperTest.API.Handler.InventoryInsightHandler
{
    public class GetMaximumBooks : IRequestHandler<BookRequest, BookDetailsInfoList>
    {
        private readonly IGprcClientCommunicator _clientClass;

        public GetMaximumBooks(IGprcClientCommunicator clientClass)
        {
            _clientClass = clientClass;
        }
        public async Task<BookDetailsInfoList> Handle(BookRequest request, CancellationToken cancellationToken)
        {
            return await _clientClass.GetMaxBook();
        }
    }
}
