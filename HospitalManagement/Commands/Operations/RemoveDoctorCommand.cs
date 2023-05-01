using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class RemoveDoctorCommand : BaseCommand
    {
        private readonly OperationsViewModel _operationsViewModel;
        public RemoveDoctorCommand(OperationsViewModel operationsViewModel) 
        {
            _operationsViewModel = operationsViewModel;
        }
        public override void Execute(object parameter)
        {
            int id = (int)parameter;
            var removedDoctor =  _operationsViewModel.CurrentValue.Doctors.FirstOrDefault(x => x.Id == id);
            if (removedDoctor == null)
                return;
            _operationsViewModel.CurrentValue.Doctors.Remove(removedDoctor);
            _operationsViewModel.DoctorValues.Add(removedDoctor);
        }
    }
}
