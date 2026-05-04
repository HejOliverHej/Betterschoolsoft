using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminView : ContentPage
{
	public AdminView()
	{
		InitializeComponent();
        BindingContext = new AdminViewModel();

    }
}