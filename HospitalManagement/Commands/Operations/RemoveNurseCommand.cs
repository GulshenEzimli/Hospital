using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class RemoveNurseCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        public RemoveNurseCommand(OperationsViewModel operationsViewModel)
        {
            _operationsViewModel = operationsViewModel;
        }
        public override void Execute(object parameter)
        {
            int id = (int)parameter;
            var removedNurse = _operationsViewModel.CurrentValue.Nurses.FirstOrDefault(x => x.Id == id);
            if (removedNurse == null)
                return;
            _operationsViewModel.CurrentValue.Nurses.Remove(removedNurse);
            _operationsViewModel.NurseValues.Add(removedNurse);
        }
    }
}
