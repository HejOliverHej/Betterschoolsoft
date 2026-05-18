using betterschoolsoft.Model;
using betterschoolsoft.Service;
using betterschoolsoft.View;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminClassViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _storage;

        private ObservableCollection<ClassGroup> _classes;
        public ObservableCollection<ClassGroup> Classes
        {
            get => _classes;
            set
            {
                _classes = value;
                OnPropertyChanged(nameof(Classes));
            }
        }

        public ICommand OpenCreateClassPopupCommand { get; }
        public ICommand OpenClassDetailsCommand { get; }

        public AdminClassViewModel()
        {
            _storage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());


            Classes = new ObservableCollection<ClassGroup>();

            OpenCreateClassPopupCommand = new Command(async () => await OpenCreateClassPopup());

            OpenClassDetailsCommand = new Command<ClassGroup>(async (c) => await OpenClassDetails(c));

            LoadClasses();
        }

        private async void LoadClasses()
        {
            var classes = await _classService.GetAllClassesAsync();

            Classes = new ObservableCollection<ClassGroup>(classes);
        }

        private async Task OpenCreateClassPopup()
        {
            var popup = new AdminClassPopup();
            var vm = new CreateClassPopupViewModel();

            popup.BindingContext = vm;

            vm.CloseRequested += () =>
            {
                Application.Current.MainPage.Navigation.PopModalAsync();
                LoadClasses(); 
            };

            await Application.Current.MainPage.Navigation.PushModalAsync(popup);
        }

        private async Task OpenClassDetails(ClassGroup classGroup)
        {
            var page = new AdminClassDetailsView();
            var vm = new AdminClassDetailsViewModel();

            page.BindingContext = vm;

            await Application.Current.MainPage.Navigation.PushAsync(page);
        }
    }
}
