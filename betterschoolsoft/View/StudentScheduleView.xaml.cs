using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class StudentScheduleView : ContentPage
{
	public StudentScheduleView()
	{
		InitializeComponent();
		BindingContext = new StudentScheduleViewModel();

    }
}