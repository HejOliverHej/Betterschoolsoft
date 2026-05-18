using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AddTeacherPopupViewModel : BaseViewModel
    {
        private readonly ClassGroup _class;
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _userStorage;

        public ObservableCollection<Teachers> AvailableTeachers { get; set; }
        public Teachers SelectedTeacher { get; set; }

        public ICommand AddCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public AddTeacherPopupViewModel(ClassGroup? classGroup)
        {
            _class = classGroup;

            _userStorage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());

            AvailableTeachers = new ObservableCollection<Teachers>();

            AddCommand = new Command(async () => await AddTeacher());
            CancelCommand = new Command(() => CloseRequested?.Invoke());

            LoadTeachers();
        }

        private async void LoadTeachers()
        {
            var users = await _userStorage.LoadAsync();
            foreach (var t in users.OfType<Teachers>())
                if (!_class.Teachers.Contains(t))
                    AvailableTeachers.Add(t);
        }

        private async Task AddTeacher()
        {
            if (SelectedTeacher == null)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Välj en lärare.", "OK");
                return;
            }

            _class.Teachers.Add(SelectedTeacher);

            var classes = await _classService.GetAllClassesAsync();
            await _classService.SaveClassesAsync(classes);

            CloseRequested?.Invoke();
        }
    }
}
