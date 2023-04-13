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
    public class OpenOtherEmployeesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IOtherEmployeeMapper _otherEmployeeMapper;
        public OpenOtherEmployeesCommand(DashboardViewModel viewModel, IOtherEmployeeMapper otherEmployeeMapper)
        {
            _viewModel = viewModel;
            _otherEmployeeMapper = otherEmployeeMapper;
        }
        public override void Execute(object parameter)
        {
            OtherEmployeesControl otherEmployeesControl = new OtherEmployeesControl();

            OtherEmployeesViewModel otherEmployeesViewModel = new OtherEmployeesViewModel(_viewModel.Db,otherEmployeesControl.ErrorDialog);

            List<OtherEmployee> otherEmployees = _viewModel.Db.OtherEmployeeRepository.Get();
            int no = 1;
            foreach (var otherEmployee in otherEmployees)
            {
                OtherEmployeeModel otherEmployeeModel = _otherEmployeeMapper.Map(otherEmployee);
                otherEmployeeModel.No = no++;
                otherEmployeesViewModel.OtherEmployeeValues.Add(otherEmployeeModel);
            }

            otherEmployeesControl.DataContext = otherEmployeesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(otherEmployeesControl);
        }
    }
}
