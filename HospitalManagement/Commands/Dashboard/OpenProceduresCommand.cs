using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Implementations;
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
    public class OpenProceduresCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public OpenProceduresCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }

        public override void Execute(object parameter)
        {
            var procedureControl = new ProceduresControl();
            var controlViewModel = new ProceduresViewModel(_serviceUnitOfWork.ProcedureService, procedureControl.ErrorDialog);

            var procedureModels = _serviceUnitOfWork.ProcedureService.GetAll();
            controlViewModel.AllValues = procedureModels;
            controlViewModel.Values = new ObservableCollection<ProcedureModel>(procedureModels);

            procedureControl.DataContext = controlViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(procedureControl);
        }

    }
}
