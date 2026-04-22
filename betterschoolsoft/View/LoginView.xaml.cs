using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class LoginView : ContentPage
{
	public LoginView()
	{
		InitializeComponent();
        BindingContext = new LoginViewModel();
    }
}