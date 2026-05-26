using betterschoolsoft.ViewModel;
namespace betterschoolsoft.View;


public partial class TeacherMessageView : ContentPage
{
	public TeacherMessageView()
	{
		InitializeComponent();
		BindingContext = new TeacherMessageViewModel();
	}
}