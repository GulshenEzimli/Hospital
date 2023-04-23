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
        private readonly INurseService _nurseService;
        public OpenNursesCommand(DashboardViewModel viewModel,INurseService nurseService)
        {
            _viewModel = viewModel;
            _nurseService = nurseService;
        }
        public override void Execute(object parameter)
        {
            NurseControl nurseControl = new NurseControl();

            NursesViewModel nursesViewModel = new NursesViewModel(_nurseService,nurseControl.ErrorDialog);

            var nurseModels = _nurseService.GetAll();

            nursesViewModel.AllValues = nurseModels;

            nursesViewModel.Values = new ObservableCollection<NurseModel>(nursesViewModel.AllValues);
            
            nurseControl.DataContext = nursesViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(nurseControl);
        }
    }
}
