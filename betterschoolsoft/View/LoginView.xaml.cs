using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class LoginView : ContentPage
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void Logginbtn_Clicked(object sender, EventArgs e)
    {
        
    }

    private async void SignInbtn_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SigninView());
    }
}