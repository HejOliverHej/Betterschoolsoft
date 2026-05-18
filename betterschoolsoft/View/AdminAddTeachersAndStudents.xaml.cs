using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminAddTeachersAndStudents : ContentPage
{
	public AdminAddTeachersAndStudents()
	{
		InitializeComponent();
		BindingContext = new AdminAddTeachersAndStudentsViewmodel();

    }
}