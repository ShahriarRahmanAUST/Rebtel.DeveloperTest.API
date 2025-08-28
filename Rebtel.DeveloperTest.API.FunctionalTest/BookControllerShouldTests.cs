using FluentAssertions;
using Rebtel.DeveloperTest.API;
using Rebtel.DeveloperTest.API.FunctionalTest;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;

namespace FunctionalTest;
[ExcludeFromCodeCoverage]
public class BookControllerShouldTests(
    CustomWebApiFactory factory) : IClassFixture<CustomWebApiFactory>
{
    [Fact]
    public async Task ReturnExpectedBook()
    {
        //var result = await factory.CreateClient().GetFromJsonAsync<AvailableBookDto>("/api/v1/Book/GetAvailableBooks?bookId=1");       
               
        //result.BookId.Should().Be(1);
    }

    [Fact]
    public async Task BookNotFound()
    {
        var result = await factory.CreateClient().GetAsync("/api/v1/Book/GetAvailableBooks?bookId=200");
        result.StatusCode.Equals(204);
    }
}