using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class SaveDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public SaveDoctorCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {
            //TO DO : implement save

            _doctorsViewModel.CurrentSituation = (int)Situations.NORMAL;
        }
    }
}
