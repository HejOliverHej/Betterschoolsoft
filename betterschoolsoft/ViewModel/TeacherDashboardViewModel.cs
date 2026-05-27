using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    internal class TeacherDashboardViewModel : BaseViewModel
    {
        
            public string TeacherName { get; set; } = "Lärare Test";

            public ObservableCollection<Lesson> TodayLessons { get; set; }

        public ICommand LogoutCommand { get; }



        public TeacherDashboardViewModel()
            {
            LogoutCommand = new Command(async () => await Logout());


        }
        private async Task Logout()
        {
            await Shell.Current.GoToAsync("//LoginView");
        }

    }
        
}
