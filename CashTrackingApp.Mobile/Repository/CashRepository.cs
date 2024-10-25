using CashTrackingApp.Mobile.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.Repository;

public class CashRepository : ICashRepository
{
    private SQLiteAsyncConnection _database;

    public CashRepository()
    {
        string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "cashtrackingapp.db");
        System.Console.WriteLine("db", dbPath);
        _database = new SQLiteAsyncConnection(dbPath);
        _database.CreateTableAsync<Balance>().Wait();
    }
    public CashRepository(SQLiteAsyncConnection database)
    {
        //Constructor used for integration testing
        _database = database;
    }

    public async Task<double> GetBalanceAsync()
    {
        Balance balance = await _database.Table<Balance>().FirstOrDefaultAsync();
        return balance?.Amount ?? 0;
    }

    public async Task<double> UpdateBalanceAsync(double newBalance)
    {
        Balance balance = await _database.Table<Balance>().FirstOrDefaultAsync();
        if (balance == null)
        {
            balance = new Balance { Amount = newBalance };
            await _database.InsertAsync(balance);
        }
        else
        {
            balance.Amount = newBalance;
            await _database.InsertAsync(balance);
        }
        return balance.Amount;
    }
}
