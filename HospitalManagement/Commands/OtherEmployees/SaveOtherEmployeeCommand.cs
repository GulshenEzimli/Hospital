using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class SaveOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _otherEmployeesViewModel;
        public SaveOtherEmployeeCommand(OtherEmployeesViewModel viewModel)
        {
            _otherEmployeesViewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            //TO DO ...

            _otherEmployeesViewModel.CurrentSituation = Situations.NORMAL;
        }
    }
}
