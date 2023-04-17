using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Operations
{
    public class SaveOperationCommand : BaseCommand
    {
        private readonly DoctorsViewModel _doctorsViewModel;
        public SaveOperationCommand(DoctorsViewModel doctorsViewModel)
        {
            _doctorsViewModel = doctorsViewModel;
        }

        public override void Execute(object parameter)
        {
            _doctorsViewModel.SetDefaultValues();
        }
    }
}
