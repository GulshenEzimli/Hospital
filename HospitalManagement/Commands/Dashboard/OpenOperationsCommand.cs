using HospitalManagement.Mappers.Implementations;
using HospitalManagement.Mappers.Interfaces;
using HospitalManagement.Models;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.ViewModels.Windows;
using HospitalManagement.Views.UserControls;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Dashboard
{
    public class OpenOperationsCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenOperationsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            OperationControl operationControl = new OperationControl();
            OperationsViewModel operationsViewModel = new OperationsViewModel(_viewModel.Db, operationControl.ErrorDialog);

            operationControl.DataContext = operationsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(operationControl);
        }
    }
}
