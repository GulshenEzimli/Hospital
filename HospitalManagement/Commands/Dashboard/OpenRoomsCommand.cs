using HospitalManagement.Models;
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
   public  class OpenRoomsCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        private readonly IServiceUnitOfWork _serviceUnitOfWork;

        public OpenRoomsCommand(DashboardViewModel viewModel, IServiceUnitOfWork serviceUnitOfWork)
        {
            _viewModel = viewModel;
            _serviceUnitOfWork = serviceUnitOfWork;
        }
        public override void Execute(object parameter)
        {
            RoomControl roomControl = new RoomControl();
            RoomsViewModel roomsViewModel = new RoomsViewModel(_serviceUnitOfWork.RoomService, roomControl.ErrorDialog);

            var roomModels = _serviceUnitOfWork.RoomService.GetAll();
            roomsViewModel.AllValues = roomModels;
            roomsViewModel.Values = new ObservableCollection<RoomModel>(roomsViewModel.Values);

            roomControl.DataContext = roomsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(roomControl);
        }
    }
}
