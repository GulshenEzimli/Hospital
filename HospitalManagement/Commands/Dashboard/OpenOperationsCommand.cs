using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenOperationsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenOperationsCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            OperationControl operationControl = new OperationControl();
            OperationsViewModel operationsViewModel = new OperationsViewModel(_serviceUnitOfWork, operationControl.ErrorDialog);

            List<OperationModel> operations = _serviceUnitOfWork.operationService.GetAll();
            operationsViewModel.AllValues = operations;
            operationsViewModel.Values = new ObservableCollection<OperationModel>(operations);
            

            operationControl.DataContext = operationsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(operationControl);
        }
    }
}
