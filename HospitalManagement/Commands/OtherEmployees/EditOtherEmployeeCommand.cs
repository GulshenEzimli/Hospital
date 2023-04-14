using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class EditOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _viewModel;
        public EditOtherEmployeeCommand(OtherEmployeesViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.CurrentSituation = Situations.EDIT;
        }
    }
}
