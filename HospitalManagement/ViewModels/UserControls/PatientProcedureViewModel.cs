using HospitalManagement.Commands.PatientProcedures;
using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Views.Components;
using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.ViewModels.UserControls
{
    public class PatientProcedureViewModel : BaseControlViewModel
    {
        public PatientProcedureViewModel(IUnitOfWork unitOfWork, ErrorDialog errorDialog) : base(unitOfWork, errorDialog)
        {
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
        

        private List<PatientProcedureModel> _patientProcedureValues;
        public List<PatientProcedureModel> PatientProcedureValues => _patientProcedureValues ?? (_patientProcedureValues = new List<PatientProcedureModel>());

        private List<string> _patients;
        public List<string> Patients => _patients ?? (_patients = new List<string>());

        private List<string> _doctors;
        public List<string> Doctors => _doctors ?? (_doctors = new List<string>());

        private List<string> _nurses;
        public List<string> Nurses => _nurses ?? (_nurses = new List<string>());

        private List<string> _procedures;
        public List<string> Procedures => _procedures ?? (_procedures = new List<string>());

        public AddPatientProcedureCommand Add => new AddPatientProcedureCommand(this);
        public DeletePatientProcedureCommand Delete => new DeletePatientProcedureCommand(this);
        public EditPatientProcedureCommand Edit => new EditPatientProcedureCommand(this);
        public RejectPatientProcedureCommand Reject => new RejectPatientProcedureCommand(this);
        public SavePatientProcedureCommand Save => new SavePatientProcedureCommand(this);

        public void SetDefaultValues()
        {
            CurrentSituation = Situations.NORMAL;
            CurrentPatientProcedure = new PatientProcedureModel();
        }
    }
}
