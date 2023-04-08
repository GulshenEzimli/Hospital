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
    public class OpenReceptionistCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenReceptionistCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            ReceptionistViewModel receptionistViewModel = new ReceptionistViewModel();
            ReceptionistControl receptionistControl = new ReceptionistControl();

            receptionistControl.DataContext = receptionistViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(receptionistControl);
        }
    }
}
