using CDB.Domain.Services.Contracts;
using CDB.Domain.Services.Dtos;
using CDB.Domain.Services.Handlers;
using CDB.UnitTests.Mocks;
using Moq;

namespace CDB.UnitTests.Units;

public class PostCdbCalculateHandlerTest
{
    private readonly Mock<IPostCdbCalculate> _serviceMock = new();
    private readonly PostCdbCalculateHandler _handler;

    public PostCdbCalculateHandlerTest()
    {
        _handler = new PostCdbCalculateHandler();
    }

    [Fact]
    public async Task HandleAsync_Should_Return_ValidResponse_WhenRequestIsValid()
    {
        var request = PostCdbRequestMock.GetDefaultInstance();

        var result = await _handler.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<PostCdbResponse>(result.Response);

        var response = result.Response as PostCdbResponse;
        Assert.NotNull(response);
        Assert.True(response!.Gross > request.InitialValue);
        Assert.True(response.Net < response.Gross);
    }

    [Fact]
    public async Task HandleAsync_Should_Return_BadRequest_WhenRequestIsInvalid()
    {
        var request = new PostCdbRequest
        {
            InitialValue = 0,
            Months = 1
        };

        var result = await _handler.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(400, result.StatusCode);
        Assert.Equal("Initial value must be greater than 0 and months must be at least 2.", result.Response);
    }

    [Fact]
    public async Task HandleAsync_Should_UseMockedServiceResponse()
    {
        var request = PostCdbRequestMock.GetDefaultInstance();
        var mockedResponse = PostCdbResponseMock.GetDefaultInstance();

        _serviceMock.Setup(x => x.HandleAsync(It.IsAny<PostCdbRequest>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new ServiceResult(200, mockedResponse));

        var result = await _serviceMock.Object.HandleAsync(request, CancellationToken.None);

        Assert.NotNull(result);
        Assert.Equal(200, result.StatusCode);
        Assert.IsType<PostCdbResponse>(result.Response);

        var response = result.Response as PostCdbResponse;
        Assert.NotNull(response);
        Assert.Equal(mockedResponse.Gross, response!.Gross);
        Assert.Equal(mockedResponse.Net, response.Net);
    }
}