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
        
            public string TeacherName { get; set; } = "Lärare Testsson";

            public ObservableCollection<Lesson> TodayLessons { get; set; }

            public ICommand OpenClassesCommand { get; }
            public ICommand OpenScheduleEditorCommand { get; }
            public ICommand OpenMessagesCommand { get; }

            public TeacherDashboardViewModel()
            {
                TodayLessons = new ObservableCollection<Lesson>
                {
                    new Lesson(1, "Matematik", "Sal 101", "08:00", "09:00", "Måndag", "1"),
                    new Lesson(2, "Svenska", "Sal 202", "10:00", "11:00", "Måndag", "1")
                };


            }
        
    }
        
}
