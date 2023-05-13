using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
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
    public class OpenPatientsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;    

        public OpenPatientsCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }   

        public override void Execute(object parameter)
        {
            var patientControl = new PatientControls();
            var controlViewModel = new PatientsViewModel(_serviceUnitOfWork.PatientService, patientControl.ErrorDialog);

            var patientModels = _serviceUnitOfWork.PatientService.GetAll();
            controlViewModel.AllValues=patientModels;
            controlViewModel.Values = new ObservableCollection<PatientModel>(patientModels);

            patientControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientControl);
        }
    }
}
