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
    public class OpenDoctorsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenDoctorsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            DoctorsViewModel doctorsViewModel = new DoctorsViewModel();
            DoctorControl doctorControl = new DoctorControl();

            doctorControl.DataContext = doctorsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(doctorControl);
        }
    }
}
