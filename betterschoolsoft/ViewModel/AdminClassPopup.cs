using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class CreateClassPopupViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _storage;

        public string ClassName { get; set; }
        public ObservableCollection<Teachers> Teachers { get; set; }
        public Teachers SelectedTeacher { get; set; }

        public ICommand CreateCommand { get; }
        public ICommand CancelCommand { get; }

        public event Action CloseRequested;

        public CreateClassPopupViewModel()
        {
            _storage = new JsonUserStorageService();
            _classService = new ClassManagerService(
                new JsonUserStorageService(),
                new JsonClassStorageService());


            Teachers = new ObservableCollection<Teachers>();

            CreateCommand = new Command(async () => await CreateClass());
            CancelCommand = new Command(() => CloseRequested?.Invoke());

            LoadTeachers();
        }

        private async void LoadTeachers()
        {
            var users = await _storage.LoadAsync();
            foreach (var t in users.OfType<Teachers>())
                Teachers.Add(t);
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
                await Application.Current.MainPage.DisplayAlert("Fel", "Välj klasslärare.", "OK");
                return;
            }

            await _classService.CreateClassAsync(ClassName, SelectedTeacher);

            CloseRequested?.Invoke();
        }
    }

}
