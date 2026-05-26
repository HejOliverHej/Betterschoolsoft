using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class CreateClassPopupViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;

        public string ClassName { get; set; }

        public ObservableCollection<Teachers> AllTeachers { get; set; }
        public Teachers SelectedTeacher { get; set; }


        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public CreateClassPopupViewModel()
        {
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());


            LoadTeachers();
            CreateCommand = new Command(async () => await CreateClass());
            CancelCommand = new Command(() => CloseRequested?.Invoke());
        }

        private async void LoadTeachers()
        {
            var users = await new JsonUserStorageService().LoadAsync();
            AllTeachers = new ObservableCollection<Teachers>(users.OfType<Teachers>());
            OnPropertyChanged(nameof(AllTeachers));
        }


        private async Task CreateClass()
        {
            if (string.IsNullOrWhiteSpace(ClassName))
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Ange klassnamn.", "OK");
                return;
            }

            if (SelectedTeacher == null)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Välj en mentor för klassen.", "OK");
                return;
            }

            try
            {
                await _classService.CreateClassAsync(ClassName, SelectedTeacher);
                CloseRequested?.Invoke();
            }
            catch (ArgumentException ex)
            {
                await Application.Current.MainPage.DisplayAlert("Fel", ex.Message, "OK");
            }
        }


    }
}
