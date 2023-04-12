using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenDoctorsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IDoctorMapper _doctorMapper;
        private readonly IPositionMapper _positionMapper;
        public OpenDoctorsCommand(DashboardViewModel viewModel, IDoctorMapper doctorMapper, IPositionMapper positionMapper)
        {
            _viewModel = viewModel;
            _doctorMapper = doctorMapper;
            _positionMapper = positionMapper;
        }
        public override void Execute(object parameter)
        {
            DoctorsViewModel doctorsViewModel = new DoctorsViewModel(_viewModel.Db);

            List<Doctor> doctors = _viewModel.Db.DoctorRepository.Get();
            int no = 1;
            foreach(Doctor doctor in doctors)
            {
                DoctorModel doctorModel = _doctorMapper.Map(doctor);
                doctorModel.No = no++;
                doctorsViewModel.Values.Add(doctorModel);
            }

            List<DoctorPosition> positions = _viewModel.Db.PositionRepository.Get();
            foreach (DoctorPosition position in positions)
            {
                PositionModel positionModel = _positionMapper.Map(position);                
                doctorsViewModel.PositionValues.Add(position.Name);
            }

            DoctorControl doctorControl = new DoctorControl();

            doctorControl.DataContext = doctorsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(doctorControl);
        }
    }
}
