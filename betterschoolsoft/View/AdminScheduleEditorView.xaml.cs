using betterschoolsoft.ViewModel;

namespace betterschoolsoft.View;

public partial class AdminScheduleEditorView : ContentPage
{
	public AdminScheduleEditorView()
	{
		InitializeComponent();
        BindingContext = new AdminScheduleEditorViewModel();

    }
}