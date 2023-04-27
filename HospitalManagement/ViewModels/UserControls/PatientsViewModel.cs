using HospitalManagement.Commands.Nurses;
using HospitalManagement.Commands.Patients;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
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
        private readonly IPatientService _patientService;

        public PatientsViewModel(IPatientService patientService,ErrorDialog errorDialog) : base(errorDialog)
        {
            _patientService = patientService;
            AllValues = new List<PatientModel>();

            SetDefaultValues();
        }

        public override string Header => "Patients";

        private Situations _currentSituation;
        public Situations CurrentSituation
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
        private PatientModel _selectValue;
        public PatientModel SelectValue
        {
            get => _selectValue;
            set
            {
                _selectValue = value;

                if (value == null)
                {
                    SetSelectValue(value);
                    SetDefaultValues();
                }
                else
                {
                    CurrentValue = new PatientModel();
                    CurrentValue = SelectValue.Clone();
                    CurrentSituation =Situations.SELECTED;
                }

                OnPropertyChanged(nameof(SelectValue));
            }
        }

        private ObservableCollection<PatientModel> _values;
        public ObservableCollection<PatientModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<PatientModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }
        }

        #region Commands
        public List<PatientModel> AllValues { get; set; }
        public AddPatientCommand Add => new AddPatientCommand(this);
        public SavePatientCommand Save => new SavePatientCommand(this, _patientService);
        public DeletePatientCommand Delete => new DeletePatientCommand(this,_patientService);
        public EditPatientCommand Edit=> new EditPatientCommand(this);
        public RejectPatientCommand Reject=>new RejectPatientCommand(this);
        #endregion

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new PatientModel();
            SetSelectValue(null);
        }
        private void SetSelectValue(PatientModel patientModel)
        {
            _selectValue = patientModel;
            OnPropertyChanged(nameof(SelectValue));

        }

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrEmpty(SearchText))
            {
                Values = new ObservableCollection<PatientModel>(AllValues);
            }
            else
            {
                var lowerText = SearchText.ToLower();

                var filteredValues = AllValues.Where(x => x.Name?.ToLower().Contains(lowerText) == true ||
                                                  x.Surname?.ToLower().Contains(lowerText) == true ||
                                                  x.BirthDate.ToString().Contains(lowerText) == true ||
                                                  x.PIN?.ToLower().Contains(lowerText) == true ||
                                                  x.PhoneNumber?.ToLower().Contains(lowerText) == true);
                Values = new ObservableCollection<PatientModel>(filteredValues);
            }
            
        }
    }
}
