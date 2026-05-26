using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;

public partial class StudentMessagesView : ContentPage
{
	public StudentMessagesView()
	{
		InitializeComponent();
		BindingContext = new StudentMessagesViewModel();
	}
}