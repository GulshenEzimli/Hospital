using HospitalManagement.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientProcedureViewModel : BaseViewModel
    {
        public PatientProcedureViewModel()
        {
            CurrentSituation = 1;
        }
        private int _currentSituation = (int)Situations.NORMAL;
        public int CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
    }
}
