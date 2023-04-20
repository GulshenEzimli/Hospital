using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Patients;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientsViewModel:BaseControlViewModel
    {
        private readonly IPatientMapper _patientMapper;

        public PatientsViewModel(IUnitOfWork unitOfWork,IPatientMapper patientMapper,ErrorDialog errorDialog) : base(unitOfWork,errorDialog)
        {
            _patientMapper = patientMapper;

            SetDefaultValues();
        }

        public override string Header => "Patients";

        private int _currentSituation;
        public int CurrentSituation
        {
            get { return _currentSituation; }
            
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private PatientModel _currentValue;
        public PatientModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private ObservableCollection<PatientModel> _values;
        public ObservableCollection<PatientModel> Values => _values ?? (_values = new ObservableCollection<PatientModel>());

        #region Commands
        public AddPatientCommand Add => new AddPatientCommand(this);
        public SavePatientCommand Save => new SavePatientCommand(this, _patientMapper);
        public DeletePatientCommand Delete => new DeletePatientCommand(this);
        public EditPatientCommand Edit=> new EditPatientCommand(this);
        public RejectPatientCommand Reject=>new RejectPatientCommand(this);
        #endregion

        public void SetDefaultValues()
        {
            CurrentSituation = (int)Situations.NORMAL;
            CurrentValue = new PatientModel();
        }
    }
}
