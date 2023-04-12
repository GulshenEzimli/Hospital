using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
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
        private readonly DashboardViewModel _viewModel;
        public AddDoctorCommand(DoctorsViewModel doctorsViewModel, DashboardViewModel viewModel)
        {
            _doctorsViewModel = doctorsViewModel;
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            _doctorsViewModel.CurrentSituation = (int)Situations.ADD;
            List<DoctorPosition> positions = _viewModel.Db.PositionRepository.Get();
            foreach (DoctorPosition position in positions)
            {
                PositionModel positionModel = new PositionModel();
                positionModel.Id = position.Id;
                positionModel.Name = position.Name;
                positionModel.DepartmentName = position.Department.Name;
                _doctorsViewModel.PositionValues.Add(position.Name);
            }
        }
    }
}
