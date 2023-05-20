using HospitalManagement.Mappers.Implementations;
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
    public class OpenOperationsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenOperationsCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            OperationControl operationControl = new OperationControl();
            OperationsViewModel operationsViewModel = new OperationsViewModel(_serviceUnitOfWork, operationControl.ErrorDialog);

            List<OperationModel> operations = _serviceUnitOfWork.OperationService.GetAll();
            operationsViewModel.AllValues = operations;
            operationsViewModel.Values = new ObservableCollection<OperationModel>(operations);

            List<PatientModel> patients = _serviceUnitOfWork.PatientService.GetAll();
            operationsViewModel.PatientValues = new List<PatientModel>(patients);

            List<RoomModel> rooms = _serviceUnitOfWork.RoomService.GetAll();
            operationsViewModel.RoomValues = new List<RoomModel>(rooms);

            var doctors = _serviceUnitOfWork.DoctorService.GetAll();
            operationsViewModel.AllDoctorValues = doctors;
            operationsViewModel.DoctorValues = new ObservableCollection<DoctorModel>(doctors);

            var nurses = _serviceUnitOfWork.NurseService.GetAll();
            operationsViewModel.AllNurseValues = nurses;
            operationsViewModel.NurseValues = new ObservableCollection<NurseModel>(nurses);

            operationControl.DataContext = operationsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(operationControl);
        }
    }
}
