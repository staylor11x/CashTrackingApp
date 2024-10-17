using Xunit;
using Moq;
using CashTrackingApp.Mobile.Service;
using CashTrackingApp.Mobile.ViewModel;

namespace CashTrackingAppTest.ViewModel;

public class CashViewModelTests
{
    private Mock<ICashService> _mockCashService;
    //private CashViewModel _viewModel;

    public CashViewModelTests()
    {
        _mockCashService = new Mock<ICashService>();
        //_viewModel = new CashViewModel(_mockCashService.Object);
    }

    [Fact]
    public void BalanceShouldBeDisplayedCorrectly()
    {
        //Arrange
        _mockCashService.Setup(service => service.GetBalance()).Returns(100.00);
        CashViewModel _viewModel = new CashViewModel(_mockCashService.Object);      //Initialise the viewModel after the service has been created
        double expected = 100.00;

        //Act
        double actual = _viewModel.Balance;
        
        //Assert
        Assert.Equal(expected, actual);
        _mockCashService.Verify(service => service.GetBalance(), Times.Once());
    }
}