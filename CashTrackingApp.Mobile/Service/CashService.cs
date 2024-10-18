using CashTrackingApp.Mobile.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.Service;

public class CashService : ICashService
{
    private readonly ICashRepository _cashRepository;

    public CashService(ICashRepository cashRepository)
    {
        _cashRepository = cashRepository;
    }

    public Task<double> UpdateBalanceAsync(double newBalance)
    {
        return _cashRepository.UpdateBalanceAsync(newBalance);
    }

    public Task<double> GetBalanceAsync()
    {
        return _cashRepository.GetBalanceAsync();
    }
}
