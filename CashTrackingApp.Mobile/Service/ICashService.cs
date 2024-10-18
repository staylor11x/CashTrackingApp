using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.Service;

public interface ICashService
{
    Task<double> GetBalanceAsync();
    Task<double> UpdateBalanceAsync(double newBalance);
}
