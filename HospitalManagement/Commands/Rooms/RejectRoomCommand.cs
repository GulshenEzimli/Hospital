using HospitalManagement.Enums;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Rooms
{
    public class RejectRoomCommand:BaseCommand
    {
        private readonly RoomsViewModel _roomsViewModel;
        public RejectRoomCommand(RoomsViewModel roomsViewModel)
        {
            _roomsViewModel = roomsViewModel;
        }

        public override void Execute(object parameter)
        {
            _roomsViewModel.SetDefaultValues();
        }
    }
}
