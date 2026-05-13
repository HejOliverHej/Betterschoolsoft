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
            
        }
    }
}
