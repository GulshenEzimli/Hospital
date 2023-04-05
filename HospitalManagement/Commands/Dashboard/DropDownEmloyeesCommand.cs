using HospitalManagement.ViewModels.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class DropDownEmloyeesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public DropDownEmloyeesCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.EmployeeSituation = !(_viewModel.EmployeeSituation);
        }
    }
}
