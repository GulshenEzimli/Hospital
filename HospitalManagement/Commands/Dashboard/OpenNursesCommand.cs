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
    public class OpenNursesCommand : BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;
        public OpenNursesCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            NurseControl nurseControl = new NurseControl();
            NursesViewModel nursesViewModel = new NursesViewModel(_serviceUnitOfWork.nurseService, nurseControl.ErrorDialog);

            var nurseModels = _serviceUnitOfWork.nurseService.GetAll();
            nursesViewModel.AllValues = nurseModels;
            nursesViewModel.Values = new ObservableCollection<NurseModel>(nursesViewModel.AllValues);
            
            //nursesViewModel.Positions  = _serviceUnitOfWork.positionService.GetAll();

            nurseControl.DataContext = nursesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(nurseControl);
        }
    }
}
