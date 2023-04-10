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
    public class OpenProceduresCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenProceduresCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            ProceduresViewModel proceduresViewModel = new ProceduresViewModel(_viewModel.Db);
            ProceduresControl proceduresControl = new ProceduresControl();

            proceduresControl.DataContext = proceduresViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(proceduresControl);
        }

    }
}
