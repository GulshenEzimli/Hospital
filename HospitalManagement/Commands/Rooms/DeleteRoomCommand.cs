using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Rooms
{
    public class DeleteRoomCommand:BaseCommand
    {
        private readonly RoomsViewModel _roomViewModel;
        public DeleteRoomCommand(RoomsViewModel roomViewModel)
        {
            _roomViewModel = roomViewModel;
        }

        public override void Execute(object parameter)
        {

        }
    }
}
