using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class DeletePatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        public DeletePatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel)
        {
            _patientProcedureViewModel = _patientProcedureViewModel;
        }
        public override void Execute(object parameter)
        {
            
        }
    }
}
