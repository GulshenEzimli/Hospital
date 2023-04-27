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
            PatientProcedureViewModel patientProcedureViewModel = new PatientProcedureViewModel(_serviceUnitOfWork.patientProcedureService, patientProcedureControl.ErrorDialog);

            var patientProcedureModels = _serviceUnitOfWork.patientProcedureService.GetAll();
            patientProcedureViewModel.AllValues = patientProcedureModels;
            patientProcedureViewModel.Values = new ObservableCollection<PatientProcedureModel>(patientProcedureModels);

            patientProcedureViewModel.Patients = _serviceUnitOfWork.patientService.GetAll();
            patientProcedureViewModel.Doctors = _serviceUnitOfWork.doctorService.GetAll();
            patientProcedureViewModel.Nurses = _serviceUnitOfWork.nurseService.GetAll();
            patientProcedureViewModel.Procedures = _serviceUnitOfWork.procedureService.GetAll();

            patientProcedureControl.DataContext = patientProcedureViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientProcedureControl);
        }
    }
}
