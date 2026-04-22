using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class Singinview : ContentPage
{
	public Singinview()
	{
		InitializeComponent();
		BindingContext = new SigninViewModel();

    }
}