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
        private readonly IOtherEmployeeService _otherEmployeeService;
        public OpenOtherEmployeesCommand(DashboardViewModel viewModel, IOtherEmployeeService otherEmployeeService)
        {
            _viewModel = viewModel;
            _otherEmployeeService = otherEmployeeService;
        }
        public override void Execute(object parameter)
        {
            OtherEmployeesControl otherEmployeesControl = new OtherEmployeesControl();
            OtherEmployeesViewModel otherEmployeesViewModel = new OtherEmployeesViewModel(_otherEmployeeService,otherEmployeesControl.ErrorDialog);

            List<OtherEmployeeModel> otherEmployeeModels = _otherEmployeeService.GetAll();
            otherEmployeesViewModel.AllValues = otherEmployeeModels;
            otherEmployeesViewModel.OtherEmployeeValues = new ObservableCollection<OtherEmployeeModel>(otherEmployeeModels);

            //List<Job> jobs = _viewModel.Db.JobRepository.Get();
            //foreach (var job in jobs)
            //{
            //    otherEmployeesViewModel.JobNames.Add(job.Name);
            //}

            otherEmployeesControl.DataContext = otherEmployeesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(otherEmployeesControl);
        }
    }
}
