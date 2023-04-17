using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class DeleteOperationCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public DeleteOperationCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
