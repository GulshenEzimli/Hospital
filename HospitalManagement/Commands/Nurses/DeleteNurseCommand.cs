using HospitalManagement.Models;
using HospitalManagement.Services.Interfaces;
using HospitalManagement.Validations.Utils;
using HospitalManagement.ViewModels;
using HospitalManagement.ViewModels.UserControls;
using HospitalManagement.Views.Dialogs;
using HospitalManagementCore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagement.Commands.Nurses
{
    public class DeleteNurseCommand : BaseCommand
    {
        private readonly NursesViewModel _nursesViewModel;
        private readonly INurseService _nurseService;
        public DeleteNurseCommand(NursesViewModel nursesViewModel, INurseService nurseService)
        {
            _nursesViewModel = nursesViewModel;
            _nurseService = nurseService;
        }

        public override void Execute(object parameter)
        {
            SureDialogViewModel sureDialogViewModel = new SureDialogViewModel();
            SureDialog sureDialog = new SureDialog();

            sureDialogViewModel.DialogText = ValidationMessageProvider.GetDeleteOperationSureQuestion();
            sureDialog.DataContext = sureDialogViewModel;

            var isSure = sureDialog.ShowDialog();
            if(isSure != true)
                return;

            var id = _nursesViewModel.SelectedValue.Id;
            _nurseService.Delete(id);

            var nurseModels = _nurseService.GetAll();

            _nursesViewModel.AllValues = nurseModels;
            _nursesViewModel.Values = new ObservableCollection<NurseModel>(nurseModels);

            _nursesViewModel.Message = new MessageModel
            {
                IsSuccess = true,
                Message = ValidationMessageProvider.GetOperationSuccessMessage(),
            };
            DoAnimation(_nursesViewModel.ErrorDialog);
        }
    }
}
