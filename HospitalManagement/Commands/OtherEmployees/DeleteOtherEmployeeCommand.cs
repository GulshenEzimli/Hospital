using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.OtherEmployees
{
    public class DeleteOtherEmployeeCommand : BaseCommand
    {
        private readonly OtherEmployeesViewModel _otherEmployeesViewModel;
        public DeleteOtherEmployeeCommand(OtherEmployeesViewModel otherEmployeesViewModel)
        {
            _otherEmployeesViewModel = otherEmployeesViewModel;
        }

        public override void Execute(object parameter)
        {
            
        }
    }
}
