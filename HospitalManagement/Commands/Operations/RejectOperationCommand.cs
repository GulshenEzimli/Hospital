using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class RejectOperationCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        public RejectOperationCommand(OperationsViewModel operationsViewModel)
        {
            _operationsViewModel = operationsViewModel;
        }

        public override void Execute(object parameter)
        {
            _operationsViewModel.SetDefaultValues();
        }
    }
}
