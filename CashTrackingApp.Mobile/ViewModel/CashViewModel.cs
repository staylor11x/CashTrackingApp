using CashTrackingApp.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.ViewModel;

public class CashViewModel : INotifyPropertyChanged
{
    private double _balance;
    private readonly ICashService _cashService;

    public event PropertyChangedEventHandler? PropertyChanged;

    public double Balance
    {
        get => _balance;
        set
        {
            if (_balance != value)
            {
                _balance = value;
                OnPropertyChanged();
            }
        }
    }

    public CashViewModel(ICashService cashService)
    {
        _cashService = cashService;
        LoadBalance();
    }

    public CashViewModel() { }  //Default constructor, allows app to build TODO find workaround

    public async void LoadBalance() //TODO UNIT TEST
    {
        Balance = await _cashService.GetBalanceAsync();
    }

    public async Task UpdateBalance(double newBalance)  //TODO UNIT TEST
    {
        await _cashService.UpdateBalanceAsync(newBalance);
        Balance = newBalance;
    }

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}