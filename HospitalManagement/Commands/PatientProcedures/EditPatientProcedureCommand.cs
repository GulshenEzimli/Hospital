using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.PatientProcedures
{
    public class EditPatientProcedureCommand : BaseCommand
    {
        private readonly PatientProcedureViewModel _viewModel;
        public EditPatientProcedureCommand(PatientProcedureViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = (int)Situations.EDIT;
        }
    }
}
