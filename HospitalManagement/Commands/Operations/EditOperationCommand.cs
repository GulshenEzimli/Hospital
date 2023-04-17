using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class EditOperationCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public EditOperationCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {
            _doctorsViewModel.CurrentSituation = Situations.EDIT;
        }
    }
}
