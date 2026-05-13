using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace betterschoolsoft.ViewModel
{
    internal class StudentDashboardViewModel : BaseViewModel
    {

        public string StudentName { get; set; } = "Test Elev";

        public ObservableCollection<Lesson> TodayLessons { get; set; }

        public ICommand OpenScheduleCommand { get; }
        public ICommand OpenAbsenceCommand { get; }
        public ICommand OpenMessagesCommand { get; }

        public StudentDashboardViewModel()
        {
            

            

        }

    }

    
}
