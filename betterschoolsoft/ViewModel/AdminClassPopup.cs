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

        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public CreateClassPopupViewModel()
        {
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());

            CreateCommand = new Command(async () => await CreateClass());
            CancelCommand = new Command(() => CloseRequested?.Invoke());
        }

        private async Task CreateClass()
        {
            if (string.IsNullOrWhiteSpace(ClassName))
            {
                await Application.Current.MainPage.DisplayAlert("Fel", "Ange klassnamn.", "OK");
                return;
            }

            // Skapa klass utan lärare
            await _classService.CreateClassAsync(ClassName, null);

            CloseRequested?.Invoke();
        }
    }
}
