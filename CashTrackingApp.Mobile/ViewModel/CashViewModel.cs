using CashTrackingApp.Mobile.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CashTrackingApp.Mobile.ViewModel
{
    public class CashViewModel : INotifyPropertyChanged
    {
        private double _balance;
        private readonly ICashService _cashService;

        public event PropertyChangedEventHandler? PropertyChanged;


        public CashViewModel(ICashService cashService)
        {
            _cashService = cashService;
            Balance = _cashService.GetBalance();
        }

        public CashViewModel() { }  //Default constructor, allows app to build

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

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
