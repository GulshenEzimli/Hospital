using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class RejectPatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _patientProcedureViewModel;
        public RejectPatientProcedureCommand(PatientProcedureViewModel patientProcedureViewModel)
        {
            _patientProcedureViewModel = patientProcedureViewModel;
        }
        public override void Execute(object parameter)
        {
            _patientProcedureViewModel.CurrentSituation = Situations.NORMAL;
        }
    }
}
