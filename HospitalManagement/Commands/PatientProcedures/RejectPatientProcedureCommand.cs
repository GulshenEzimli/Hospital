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
        private readonly PatientProcedureViewModel _viewModel;
        public RejectPatientProcedureCommand(PatientProcedureViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = Situations.NORMAL;
        }
    }
}
