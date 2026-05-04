using betterschoolsoft.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace betterschoolsoft.ViewModel
{
    internal class StudentAbsenceViewModel : BaseViewModel
    {
        public ObservableCollection<Absence> Absences { get; set; }

        public StudentAbsenceViewModel()
        {
            Absences = new ObservableCollection<Absence>
            {
                new Absence(1, 10, 2, DateTime.Now.AddDays(-1),5),
                new Absence(2, 10, 3, DateTime.Now.AddDays(-3), 10),
                new Absence(3, 10, 1, DateTime.Now.AddDays(-7), 20)
            };
        }
    }
}
