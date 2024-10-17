using Moq;
using Xunit;
using CashTrackingApp.Mobile.Repository;
using CashTrackingApp.Mobile.Service;

namespace CashTrackingAppTest.Service;

public class CashServiceTest
{
    private Mock<ICashRepository> _mockRepo;
    private CashService _cashService;

    //Constructor for setting up the mock and service before each test
    public CashServiceTest() 
    {
        _mockRepo = new Mock<ICashRepository>();
        _cashService = new CashService( _mockRepo.Object ); //sut
    }


    [Fact]
    public void GetBalanceShouldReturnCorrectBalance()
    {
        //Arrange
        _mockRepo.Setup(repo => repo.GetBalance()).Returns(100.00);
        double expected = 100.00;

        //Act
        double actual = _cashService.GetBalance();

        //Assert
        Assert.Equal(expected, actual);  
        _mockRepo.Verify(repo => repo.GetBalance(), Times.Once());
    }

    [Fact]
    public void UpdateBalanceShouldReturnCorrectBalance()
    {
        //Arrange
        double newBalance = 150.00;
        _mockRepo.Setup(repo => repo.UpdateBalance(newBalance)).Returns(newBalance);

        double actual = _cashService.UpdateBalance(newBalance);

        //Assert 
        Assert.Equal(newBalance, actual);
        _mockRepo.Verify(repo => repo.UpdateBalance(newBalance), Times.Once());
    }
}
