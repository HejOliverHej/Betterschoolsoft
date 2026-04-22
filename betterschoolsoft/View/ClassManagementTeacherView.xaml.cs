using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class ClassManagementTeacherView : ContentPage
{
	public ClassManagementTeacherView()
	{
		InitializeComponent();
		BindingContext = new ClassManagementTeacherViewModel();

    }
}