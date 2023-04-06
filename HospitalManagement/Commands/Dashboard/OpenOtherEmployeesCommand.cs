using HospitalManagement.ViewModels.UserControls;
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
            OtherEmployeesViewModel otherEmployeesViewModel = new OtherEmployeesViewModel();
            OtherEmployeesControl otherEmployeesControl = new OtherEmployeesControl();

            otherEmployeesControl.DataContext = otherEmployeesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(otherEmployeesControl);
        }
    }
}
