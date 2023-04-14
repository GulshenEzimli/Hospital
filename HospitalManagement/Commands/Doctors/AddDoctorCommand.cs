using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Doctors
{
    public class AddDoctorCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public AddDoctorCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {
            _doctorsViewModel.CurrentSituation = Situations.ADD;
        }
    }
}
