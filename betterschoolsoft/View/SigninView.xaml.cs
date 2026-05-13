using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class SigninView : ContentPage
{
	public SigninView()
	{
		InitializeComponent();
		BindingContext = new SigninViewModel();

    }
}