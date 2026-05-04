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
            TodayLessons = new ObservableCollection<Lesson>
            {
                new Lesson(
                    id: 1,
                    teacher: "Anna Larsson",
                    classRoom: "Sal 204",
                    startTime: "08:00",
                    endTime: "09:00",
                    weekday: "Wednesday",
                    classid: "1"
                ),

                new Lesson(
                    id: 2,
                    teacher: "Peter Svensson",
                    classRoom: "Sal 105",
                    startTime: "09:15",
                    endTime: "10:00",
                    weekday: "Wednesday",
                    classid: "1"
                ),

                new Lesson(
                    id: 3,
                    teacher: "Maria Ek",
                    classRoom: "Gympasal",
                    startTime: "10:30",
                    endTime: "11:30",
                    weekday: "Wednesday",
                    classid: "1"
                )
            };

            

        }

    }

    
}
