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
    public class OpenAdminsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenAdminsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            AdminsViewModel adminsViewModel = new AdminsViewModel();
            AdminControl adminControl = new AdminControl();

            adminControl.DataContext = adminsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(adminControl);
        }
    }
}
