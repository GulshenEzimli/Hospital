using HospitalManagement.Enums;
using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations;
using HospitalManagement.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Rooms
{
    public class SaveRoomCommand:BaseCommand
    {
        private readonly RoomsViewModel _roomsViewModel;
        private readonly IRoomService _roomService;

        public SaveRoomCommand(RoomsViewModel roomsViewModel, IRoomService roomService)
        {
            _roomsViewModel = roomsViewModel;
            _roomService = roomService;
        }
        public override void Execute(object parameter)
        {
            //TO DO ...
            if(!RoomValidation.IsValid(_roomsViewModel.CurrentValue, out string message))
            {
                _roomsViewModel.Message = new MessageModel
                {
                    IsSuccess = false,
                    Message = message
                };
                DoAnimation(_roomsViewModel.ErrorDialog);
                return;
            }

            _roomService.Save(_roomsViewModel.CurrentValue);

            var roomModels = _roomService.GetAll();
            _roomsViewModel.AllValues = roomModels;

        }
    }
}
