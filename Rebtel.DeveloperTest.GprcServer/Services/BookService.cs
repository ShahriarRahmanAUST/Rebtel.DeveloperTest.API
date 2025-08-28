using Google.Protobuf.WellKnownTypes;
using GprcServer;
using Grpc.Core;
using Rebtel.DeveloperTest.SL.DTO;
using Rebtel.DeveloperTest.SL.Interfaces;

namespace Rebtel.DeveloperTest.GprcServer.Services;

public class BookService : BookDetails.BookDetailsBase
{
    private readonly ILogger<BookService> _logger;
    private readonly IBookLogic bookLogic;

    public BookService(ILogger<BookService> logger, IBookLogic bookLogic)
    {
        _logger = logger;
        this.bookLogic = bookLogic;
    }

    public override async Task<BookDetailsInfoList> GetMaxBorrowedBook(Empty request, ServerCallContext context)
    {
        var bookLIst = await this.bookLogic.GetMaxBook();

        BookDetailsInfoList bookDetailsInfoList = new BookDetailsInfoList();

        foreach (var bookDto in bookLIst)
        {
            bookDetailsInfoList.BookDetailsInfoList_.Add(new BookDetailsInfo
            {
                Author = bookDto.Author,
                BookId = bookDto.BookId,
                Name = bookDto.Name,
                NumberOfCopies = bookDto.NumberOfCopies,
                Pages = bookDto.Pages
            });
        }

        return await Task.FromResult(bookDetailsInfoList);
    }

    //public override async Task<BookDetailsInfoList> GetMaxBorrowedBook(HelloRequest request, ServerCallContext context)
    //{
    //    var bookLIst = await this.bookLogic.GetMaxBook();

    //    BookDetailsInfoList bookDetailsInfoList = new BookDetailsInfoList();

    //    foreach (var bookDto in bookLIst)
    //    {
    //        bookDetailsInfoList.BookDetailsInfoList_.Add(new BookDetailsInfo
    //        {
    //            Author = bookDto.Author,
    //            BookId = bookDto.BookId,
    //            Name = bookDto.Name,
    //            NumberOfCopies = bookDto.NumberOfCopies,
    //            Pages = bookDto.Pages
    //        });
    //    }

    //    return await Task.FromResult(bookDetailsInfoList);
    //}

    public override async Task<BookDetailsInfoList> GetBorrowingPattern(BorrowingPatternRequest request,
        ServerCallContext context)
    {
        var bookLIst = await this.bookLogic.BookListByBorrower(request.BorrowerId, request.BookToExcludeId);
        BookDetailsInfoList bookDetailsInfoList = new BookDetailsInfoList();

        foreach (var bookDto in bookLIst)
        {
            bookDetailsInfoList.BookDetailsInfoList_.Add(new BookDetailsInfo
            {
                Author = bookDto.Author,
                BookId = bookDto.BookId,
                Name = bookDto.Name,
                NumberOfCopies = bookDto.NumberOfCopies,
                Pages = bookDto.Pages
            });
        }

        return await Task.FromResult(bookDetailsInfoList);
    }
}