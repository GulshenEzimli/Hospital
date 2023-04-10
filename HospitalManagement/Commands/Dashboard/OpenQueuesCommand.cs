using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagement.Views.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenQueuesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenQueuesCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            QueuesViewModel queuesViewModel = new QueuesViewModel(_viewModel.Db);
            QueuesControl queuesControl = new QueuesControl();

            queuesControl.DataContext= queuesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(queuesControl);
        }
    }
}
