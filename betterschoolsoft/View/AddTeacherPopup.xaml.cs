using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AddTeacherPopup : ContentPage
{
	public AddTeacherPopup()
	{
		InitializeComponent();
        BindingContext = new AddTeacherPopupViewModel();
    }
}