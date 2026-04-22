using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class StudentManagementTeacherView : ContentPage
{
	public StudentManagementTeacherView()
	{
		InitializeComponent();
		BindingContext = new StudentManagementTeacherViewModel();

    }
}