using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.Model;

public class Balance
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public double Amount { get; set; }

    public Balance()
    {
    }
}
