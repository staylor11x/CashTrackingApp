using CashTrackingApp.Mobile.ViewModel;

namespace CashTrackingApp.Mobile.View;

public partial class CashBalancePage : ContentPage
{
	public CashBalancePage(CashViewModel cashViewModel)
	{
		InitializeComponent();
		BindingContext = cashViewModel;
	}
}