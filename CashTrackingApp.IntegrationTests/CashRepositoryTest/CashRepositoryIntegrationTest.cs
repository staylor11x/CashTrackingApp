using SQLite;
using CashTrackingApp.Mobile.Repository;
using CashTrackingApp.Mobile.Model;

namespace CashTrackingApp.IntegrationTests.CashRepositoryTest;

public class CashRepositoryIntegrationTest
{
    private readonly SQLiteAsyncConnection _database;
    private CashRepository _cashRepository;

    public CashRepositoryIntegrationTest()
    {
        _database = new SQLiteAsyncConnection(":memory:");
        _database.CreateTableAsync<Balance>().Wait();

        _cashRepository = new CashRepository(_database);
    }

    [Fact]
    public async Task GetBalance_ShouldReturnInitialZeroBalance()
    {
        //Act
        double balance = await _cashRepository.GetBalanceAsync();

        //Assert
        Assert.Equal(0, balance);
    }

    [Fact]
    public async Task UpdateBalance_ShouldPersistBalance()
    {
        //Arrange
        double newBalance = 150.00;

        //Act
        await _cashRepository.UpdateBalanceAsync(newBalance);
        double actual = await _cashRepository.GetBalanceAsync();    //the balance from the db

        //Assert
        Assert.Equal(newBalance, actual);
    }
}