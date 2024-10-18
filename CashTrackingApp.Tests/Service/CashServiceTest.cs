using Moq;
using Xunit;
using CashTrackingApp.Mobile.Repository;
using CashTrackingApp.Mobile.Service;

namespace CashTrackingApp.Tests.Service;

public class CashServiceTest
{
    private Mock<ICashRepository> _mockRepo;
    private CashService _cashService;

    //Constructor for setting up the mock and service before each test
    public CashServiceTest()
    {
        _mockRepo = new Mock<ICashRepository>();
        _cashService = new CashService(_mockRepo.Object); //sut
    }


    [Fact]
    public async Task GetBalanceAsyncShouldReturnCorrectBalance()
    {
        //Arrange
        _mockRepo.Setup(repo => repo.GetBalanceAsync()).ReturnsAsync(100.00);
        double expected = 100.00;

        //Act
        double actual = await _cashService.GetBalanceAsync();

        //Assert
        Assert.Equal(expected, actual);
        _mockRepo.Verify(repo => repo.GetBalanceAsync(), Times.Once());
    }

    [Fact]
    public async Task UpdateBalanceShouldReturnCorrectBalance()
    {
        //Arrange
        double newBalance = 150.00;
        _mockRepo.Setup(repo => repo.UpdateBalanceAsync(newBalance)).ReturnsAsync(newBalance);

        //Act
        double actual = await _cashService.UpdateBalanceAsync(newBalance);

        //Assert 
        Assert.Equal(newBalance, actual);
        _mockRepo.Verify(repo => repo.UpdateBalanceAsync(newBalance), Times.Once());
    }
}
