using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenPatientsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenPatientsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }   

        public override void Execute(object parameter)
        {
            PatientControls patientControls = new PatientControls();
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(patientControls);
        }
    }
}
