using Xunit;
using Moq;
using CashTrackingApp.Mobile.Service;
using CashTrackingApp.Mobile.ViewModel;

namespace CashTrackingApp.Tests.ViewModel;

public class CashViewModelTests
{
    private Mock<ICashService> _mockCashService;

    public CashViewModelTests()
    {
        _mockCashService = new Mock<ICashService>();
    }

    [Fact]
    public void BalanceShouldBeDisplayedCorrectly()
    {
        //Arrange
        _mockCashService.Setup(service => service.GetBalanceAsync()).ReturnsAsync(100.00);
        CashViewModel _viewModel = new CashViewModel(_mockCashService.Object);      //Initialise the viewModel after the service has been created
        double expected = 100.00;

        //Act
        double actual = _viewModel.Balance;

        //Assert
        Assert.Equal(expected, actual);
        _mockCashService.Verify(service => service.GetBalanceAsync(), Times.Once());
    }
}