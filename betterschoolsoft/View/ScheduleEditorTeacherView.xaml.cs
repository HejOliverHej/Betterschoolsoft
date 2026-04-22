using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class ScheduleEditorTeacherView : ContentPage
{
	public ScheduleEditorTeacherView()
	{
		InitializeComponent();
		BindingContext = new ScheduleEditorTeacherViewModel();
    }
}