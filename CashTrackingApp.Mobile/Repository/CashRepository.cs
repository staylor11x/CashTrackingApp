using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.Repository;

public class CashRepository : ICashRepository
{
    public double GetBalance()
    {
        return 100.00;
    }

    public double UpdateBalance(double newBalance)
    {
        return newBalance;
    }
}
