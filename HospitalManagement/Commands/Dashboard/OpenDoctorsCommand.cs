using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Models.Implementations;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenDoctorsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenDoctorsCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {

            DoctorControl doctorControl = new DoctorControl();
            DoctorsViewModel doctorsViewModel = new DoctorsViewModel(_serviceUnitOfWork, doctorControl.ErrorDialog);

            List<DoctorModel> doctorModels = _serviceUnitOfWork.DoctorService.GetAll();
            doctorsViewModel.AllValues = doctorModels;
            doctorsViewModel.Values = new ObservableCollection<DoctorModel>(doctorModels);

            List<PositionModel> positions = _serviceUnitOfWork.PositionService.GetAll();
            doctorsViewModel.PositionValues = new List<PositionModel>(positions);
            
            doctorControl.DataContext = doctorsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(doctorControl);
        }
    }
}
