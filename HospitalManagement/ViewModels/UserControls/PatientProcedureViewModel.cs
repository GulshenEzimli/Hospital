using HospitalManagement.Commands.PatientProcedures;
using HospitalManagement.Enums;
using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
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

        private PatientProcedureModel _currentPatientProcedure;
        public PatientProcedureModel CurrentPatientProcedure
        {
            get => _currentPatientProcedure;
            set
            {
                _currentPatientProcedure = value;
                OnPropertyChanged(nameof(CurrentPatientProcedure));
            }
        }
        
        public List<PatientProcedureModel> AllValues { get; set; }

        private ObservableCollection<PatientProcedureModel> _patientProcedureValues;
        public ObservableCollection<PatientProcedureModel> PatientProcedureValues
        {
            get => _patientProcedureValues ?? (_patientProcedureValues = new ObservableCollection<PatientProcedureModel>());
            set
            {
                _patientProcedureValues = value;
                OnPropertyChanged(nameof(PatientProcedureValues));
            }

        }

        private List<PatientModel> _patients;
        public List<PatientModel> Patients => _patients ?? (_patients = new List<PatientModel>());

        private List<DoctorModel> _doctors;
        public List<DoctorModel> Doctors => _doctors ?? (_doctors = new List<DoctorModel>());

        private List<NurseModel> _nurses;
        public List<NurseModel> Nurses => _nurses ?? (_nurses = new List<NurseModel>());

        private List<ProcedureModel> _procedures;
        public List<ProcedureModel> Procedures => _procedures ?? (_procedures = new List<ProcedureModel>());

        public AddPatientProcedureCommand Add => new AddPatientProcedureCommand(this);
        public DeletePatientProcedureCommand Delete => new DeletePatientProcedureCommand(this, _patientProcedureService);
        public EditPatientProcedureCommand Edit => new EditPatientProcedureCommand(this);
        public RejectPatientProcedureCommand Reject => new RejectPatientProcedureCommand(this);
        public SavePatientProcedureCommand Save => new SavePatientProcedureCommand(this,_patientProcedureService);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentPatientProcedure = new PatientProcedureModel();
        }

        protected override void OnSearchTextChanged()
        {
            throw new NotImplementedException();
        }
    }
}
