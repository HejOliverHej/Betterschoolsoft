using betterschoolsoft.Model;
using betterschoolsoft.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    public class AdminClassViewModel : BaseViewModel
    {
        private readonly ClassManagerService _classService;
        private readonly IUserStorageService _storage;

        public ObservableCollection<ClassGroup> Classes { get; set; }

        public ICommand CreateClassCommand { get; }

        public AdminClassViewModel()
        {
            _storage = new JsonUserStorageService();
            _classService = new ClassManagerService(_storage);

            Classes = new ObservableCollection<ClassGroup>();

            CreateClassCommand = new Command(async () => await CreateClass());

            LoadClasses();
        }

        private async void LoadClasses()
        {
            var classes = await _classService.GetAllClassesAsync();
            Classes.Clear();
            foreach (var c in classes)
                Classes.Add(c);
        }

        private async Task CreateClass()
        {
            // Här kan vi lägga UI för att välja lärare + klassnamn
            await Application.Current.MainPage.DisplayAlert("Info", "Skapa klass UI kommer här", "OK");
        }
    }

}
