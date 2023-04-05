using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
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
        public OpenOtherEmployeesCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            OtherEmployeesControol otherEmployeesControol = new OtherEmployeesControol();
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(otherEmployeesControol);
        }
    }
}
