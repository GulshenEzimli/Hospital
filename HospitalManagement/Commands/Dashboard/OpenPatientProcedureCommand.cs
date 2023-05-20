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
    public class OpenPatientProcedureCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenPatientProcedureCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            PatientProcedureControl patientProcedureControl = new PatientProcedureControl();
            PatientProcedureViewModel patientProcedureViewModel = new PatientProcedureViewModel(_serviceUnitOfWork.PatientProcedureService, patientProcedureControl.ErrorDialog);

            var patientProcedureModels = _serviceUnitOfWork.PatientProcedureService.GetAll();
            patientProcedureViewModel.AllValues = patientProcedureModels;
            patientProcedureViewModel.Values = new ObservableCollection<PatientProcedureModel>(patientProcedureModels);

            patientProcedureViewModel.Load();

            patientProcedureControl.DataContext = patientProcedureViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientProcedureControl);
        }
    }
}
