using HospitalManagement.Commands.PatientProcedures;
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

        public AddPatientProcedureCommand Add => new AddPatientProcedureCommand(this);
        public DeletePatientProcedureCommand Delete => new DeletePatientProcedureCommand(this);
        public EditPatientProcedureCommand Edit => new EditPatientProcedureCommand(this);
        public RejectPatientProcedureCommand Reject => new RejectPatientProcedureCommand(this);
        public SavePatientProcedureCommand Save => new SavePatientProcedureCommand(this);
    }
}
