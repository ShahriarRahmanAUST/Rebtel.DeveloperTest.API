using FluentAssertions;
using Rebtel.DeveloperTest.API;
using Rebtel.DeveloperTest.API.FunctionalTest;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using GPRCClientDLL;
using Rebtel.DeveloperTest.SL.DTO;

namespace FunctionalTest;
[ExcludeFromCodeCoverage]
public class BookControllerShouldTests(
    CustomWebApiFactory factory) : IClassFixture<CustomWebApiFactory>
{
    [Fact]
    public async Task ReturnExpectedBook()
    {
        var result = await factory.CreateClient().GetFromJsonAsync<BorrowerReadingRate>("/api/v1/UserActivity/GetReadingRateOfBorrower?borrowerId=1");

        result.BorrowerId.Should().Be(1);
        result.BorrowerReadingRatePagePerDay.Should().Be(6);
    }

    [Fact]
    public async Task BookNotFound()
    {
        var result = await factory.CreateClient().GetAsync("/api/v1/UserActivity/GetReadingRateOfBorrower?borrowerId=100");
        result.StatusCode.Equals(204);
    }
}