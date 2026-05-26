using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminClassView : ContentPage
{
	public AdminClassView()
	{
		InitializeComponent();
        BindingContext = new AdminClassViewModel();

    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (BindingContext is AdminClassViewModel vm)
            vm.ReloadClasses();
    }
}