using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class StudentAbsenceView : ContentPage
{
	public StudentAbsenceView()
	{
		InitializeComponent();
        BindingContext = new StudentAbsenceViewModel();
    }
}