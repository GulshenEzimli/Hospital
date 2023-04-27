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
    public class OpenOtherEmployeesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenOtherEmployeesCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            OtherEmployeesControl otherEmployeesControl = new OtherEmployeesControl();
            OtherEmployeesViewModel otherEmployeesViewModel = new OtherEmployeesViewModel(_serviceUnitOfWork.otherEmployeeService, otherEmployeesControl.ErrorDialog);

            List<OtherEmployeeModel> otherEmployeeModels = _serviceUnitOfWork.otherEmployeeService.GetAll();
            otherEmployeesViewModel.AllValues = otherEmployeeModels;
            otherEmployeesViewModel.Values = new ObservableCollection<OtherEmployeeModel>(otherEmployeeModels);

            otherEmployeesViewModel.JobNames = _serviceUnitOfWork.jobService.GetAll();
            

            otherEmployeesControl.DataContext = otherEmployeesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(otherEmployeesControl);
        }
    }
}
