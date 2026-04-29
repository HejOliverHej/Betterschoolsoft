using betterschoolsoft.ViewModel;
using System.Text.Json;
using System.Windows.Input;
using betterschoolsoft.Model;
namespace betterschoolsoft.View;

public partial class SigninView : ContentPage
{
	public SigninView()
	{
		InitializeComponent();
		BindingContext = new SigninViewModel();

    }
}