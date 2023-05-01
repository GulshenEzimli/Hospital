using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagement.Commands.Rooms
{
    public class DeleteRoomCommand:BaseCommand
    {
        private readonly RoomsViewModel _roomViewModel;
        private readonly IRoomService _roomService;

        public DeleteRoomCommand(RoomsViewModel roomViewModel, IRoomService roomService)
        {
            _roomViewModel = roomViewModel;
            _roomService = roomService;
        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;

            var isSure = sureDialog.ShowDialog();
            if (isSure != true)
                return;

            var id = _roomViewModel.SelectedValue.Id;
            _roomService.Delete(id);

            var roomModels = _roomService.GetAll();
            _roomViewModel.AllValues = roomModels;
            _roomViewModel.Values = new ObservableCollection<RoomModel>(roomModels);

            _roomViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage()
            };
            DoAnimation(_roomViewModel.ErrorDialog);
        }
    }
}
