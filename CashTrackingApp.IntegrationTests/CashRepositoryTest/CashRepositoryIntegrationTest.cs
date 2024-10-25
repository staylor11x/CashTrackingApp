using SQLite;
using CashTrackingApp.Mobile.Repository;
using CashTrackingApp.Mobile.Model;
using Xunit;

namespace CashTrackingApp.IntegrationTests.CashRepositoryTest;

public class CashRepositoryIntegrationTest : IAsyncLifetime
{
    private SQLiteAsyncConnection? _database;
    private CashRepository? _cashRepository;

    // This method is called before each test method
    public async Task InitializeAsync()
    {
        _database = new SQLiteAsyncConnection(":memory:");
        await _database.CreateTableAsync<Balance>();
        _cashRepository = new CashRepository(_database);
    }

    // This method is called after each test method
    public async Task DisposeAsync()
    {
        if (_database != null)
        {
            await _database.CloseAsync();
            _database = null;
            _cashRepository = null;
        }
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
