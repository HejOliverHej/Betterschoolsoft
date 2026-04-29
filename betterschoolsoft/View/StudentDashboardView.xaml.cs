using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class StudentDashboardView : ContentPage
{
	public StudentDashboardView()
	{
		InitializeComponent();
        BindingContext = new StudentDashboardViewModel();

    }
}