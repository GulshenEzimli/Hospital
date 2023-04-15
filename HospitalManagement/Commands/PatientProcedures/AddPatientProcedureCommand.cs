using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class AddPatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        public AddPatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
        }
        public override void Execute(object parameter)
        {
            _patientProcedureViewModel.CurrentSituation = Situations.ADD;
        }
    }
}
