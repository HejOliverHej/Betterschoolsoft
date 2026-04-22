using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class TeacherDashboardView : ContentPage
{
	public TeacherDashboardView()
	{
		InitializeComponent();
		BindingContext = new TeacherDashboardViewModel();
	}
}