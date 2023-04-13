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
        }
        public override string Header => "Patients and Procedures";
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

        public AddPatientProcedureCommand Add => new AddPatientProcedureCommand(this);
        public DeletePatientProcedureCommand Delete => new DeletePatientProcedureCommand(this);
        public EditPatientProcedureCommand Edit => new EditPatientProcedureCommand(this);
        public RejectPatientProcedureCommand Reject => new RejectPatientProcedureCommand(this);
        public SavePatientProcedureCommand Save => new SavePatientProcedureCommand(this);
    }
}
