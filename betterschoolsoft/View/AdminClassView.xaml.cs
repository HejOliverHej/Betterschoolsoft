using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminClassView : ContentPage
{
	public AdminClassView()
	{
		InitializeComponent();
        BindingContext = new AdminClassViewModel();

    }
}