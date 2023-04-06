using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class EditDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public EditDoctorCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {
            _doctorsViewModel.CurrentSituation = (int)Situations.EDIT;
        }
    }
}
