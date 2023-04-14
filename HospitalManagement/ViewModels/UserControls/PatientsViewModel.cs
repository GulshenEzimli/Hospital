using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Patients;
using HospitalManagement.Enums;
using HospitalManagement.Models;
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
        }
        private Situations _currentSituation = Situations.NORMAL;
        public Situations CurrentSituation
        {
            get { return _currentSituation; }
            
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }
        private List<PatientModel> _values;
        public List<PatientModel> Values => _values ?? (_values = new List<PatientModel>());

        public AddPatientCommand Add => new AddPatientCommand(this);
        public DeletePatientCommand Delete => new DeletePatientCommand(this);
        public EditPatientCommand Edit=> new EditPatientCommand(this);
        public RejectPatientCommand Reject=>new RejectPatientCommand(this);
        public SavePatientCommand Save => new SavePatientCommand(this);
    }
}
