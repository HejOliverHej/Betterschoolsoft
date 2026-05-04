using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminMessageView : ContentPage
{
	public AdminMessageView()
	{
		InitializeComponent();
        BindingContext = new AdminMessageViewModel();

    }
}