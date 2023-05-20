using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenReceptionistCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public OpenReceptionistCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            ReceptionistControl receptionistControl = new ReceptionistControl();
            ReceptionistViewModel receptionistViewModel = new ReceptionistViewModel(_serviceUnitOfWork.ReceptionistService, receptionistControl.ErrorDialog);

            var receptionistModels = _serviceUnitOfWork.ReceptionistService.GetAll();
            receptionistViewModel.AllValues = receptionistModels;
            receptionistViewModel.Values = new ObservableCollection<Models.ReceptionistModel>(receptionistViewModel.AllValues);

            receptionistViewModel.Load();

            receptionistControl.DataContext = receptionistViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(receptionistControl);
        }
    }
}
