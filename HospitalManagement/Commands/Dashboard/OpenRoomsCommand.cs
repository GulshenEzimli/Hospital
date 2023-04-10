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
   public  class OpenRoomsCommand:BaseCommand
    {
        private readonly DashboardViewModel _viewModel;
        public OpenRoomsCommand(DashboardViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            RoomsViewModel roomsViewModel = new RoomsViewModel(_viewModel.Db);
            RoomControl roomControl = new RoomControl();

            roomControl.DataContext = roomsViewModel;
            _viewModel.CenterGrid.Children.Clear();
            _viewModel.CenterGrid.Children.Add(roomControl);
        }
    }
}
