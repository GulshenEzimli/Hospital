using HospitalManagement.Commands.PatientProcedures;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientProcedureViewModel : BaseControlViewModel
    {
        private readonly IPatientProcedureService _patientProcedureService;
        public PatientProcedureViewModel(IPatientProcedureService patientProcedureService, ErrorDialog errorDialog) : base(errorDialog)
        {
            AllValues = new List<PatientProcedureModel>();
            _patientProcedureService = patientProcedureService;
            SetDefaultValues();
        }
        public override string Header => "Patients and Procedures";
        private Situations _currentSituation;
        public Situations CurrentSituation
        {
            get => _currentSituation;
            set
            {
                _currentSituation = value;
                OnPropertyChanged(nameof(CurrentSituation));
            }
        }

        private PatientProcedureModel _currentValue;
        public PatientProcedureModel CurrentValue
        {
            get => _currentValue;
            set
            {
                _currentValue = value;
                OnPropertyChanged(nameof(CurrentValue));
            }
        }

        private PatientProcedureModel _selectedValue;
        public PatientProcedureModel SelectedValue
        {
            get => _selectedValue;
            set
            {
                SetSelectedValue(value);
                if (value == null)
                    SetDefaultValues();
                else
                {
                    CurrentValue = new PatientProcedureModel();
                    CurrentValue = SelectedValue.Clone();
                    CurrentSituation = Situations.SELECTED;
                }
                OnPropertyChanged(nameof(_selectedValue));
            }
        }

        public List<PatientProcedureModel> AllValues { get; set; }

        private ObservableCollection<PatientProcedureModel> _values;
        public ObservableCollection<PatientProcedureModel> Values
        {
            get => _values ?? (_values = new ObservableCollection<PatientProcedureModel>());
            set
            {
                _values = value;
                OnPropertyChanged(nameof(Values));
            }

        }

        private List<PatientModel> _patients;
        public List<PatientModel> Patients
        {
            get => _patients ?? (_patients = new List<PatientModel>());
            set
            {
                _patients = value;
            }
        }

        private List<DoctorModel> _doctors;
        public List<DoctorModel> Doctors
        {
            get => _doctors ?? (_doctors = new List<DoctorModel>());
            set
            {
                _doctors = value;
            }
        }

        private List<NurseModel> _nurses;
        public List<NurseModel> Nurses
        {
            get => _nurses ?? (_nurses = new List<NurseModel>());
            set
            {
                _nurses = value;
            }
        }

        private List<ProcedureModel> _procedures;
        public List<ProcedureModel> Procedures
        {
            get => _procedures ?? (_procedures = new List<ProcedureModel>());
            set
            {
                _procedures = value;
            }
        }

        public AddPatientProcedureCommand Add => new AddPatientProcedureCommand(this);
        public DeletePatientProcedureCommand Delete => new DeletePatientProcedureCommand(this, _patientProcedureService);
        public EditPatientProcedureCommand Edit => new EditPatientProcedureCommand(this);
        public RejectPatientProcedureCommand Reject => new RejectPatientProcedureCommand(this);
        public SavePatientProcedureCommand Save => new SavePatientProcedureCommand(this, _patientProcedureService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentValue = new PatientProcedureModel();
            SetSelectedValue(null);
        }

        public void SetSelectedValue(PatientProcedureModel model)
        {
            _selectedValue = model;
            OnPropertyChanged(nameof(SelectedValue));
        }

        protected override void OnSearchTextChanged()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                Values = new ObservableCollection<PatientProcedureModel>(AllValues);
            }
            else
            {
                string lowerText = SearchText.ToLower();
                var filteredValues = AllValues.Where(x => x.DisplayDoctor?.ToLower().Contains(lowerText) == true ||
                                                        x.DisplayNurse?.ToLower().Contains(lowerText) == true ||
                                                        x.DisplayPatient?.ToLower().Contains(lowerText) == true ||
                                                        x.UseDate.ToString(SystemConstants.DateDisplayFormat).ToLower().Contains(lowerText) == true);
                Values = new ObservableCollection<PatientProcedureModel>(filteredValues);
            }
        }
    }
}
