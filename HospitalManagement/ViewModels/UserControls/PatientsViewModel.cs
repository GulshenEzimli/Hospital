using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Patients;
using HospitalManagement.Enums;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientsViewModel:BaseViewModel
    {
        public PatientsViewModel(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            CurrentSituation = 1;
        }
        private int _currentSituation = (int)Situations.NORMAL;
        public int CurrentSituation
        {
            get { return _currentSituation; }
            
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
        public AddPatientCommand Add => new AddPatientCommand(this);
        public DeletePatientCommand Delete => new DeletePatientCommand(this);
        public EditPatientCommand Edit=> new EditPatientCommand(this);
        public RejectPatientCommand Reject=>new RejectPatientCommand(this);
        public SavePatientCommand Save => new SavePatientCommand(this);
    }
}
