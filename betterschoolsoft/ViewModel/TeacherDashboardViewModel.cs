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

           

            public TeacherDashboardViewModel()
            {
                


            }
        
    }
        
}
